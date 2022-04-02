using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.NPCs;

public class DarkMotherSlime : ModNPC
{
    int suicideTimer;
    int flashCounter;
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dark Mother Slime");
        Main.npcFrameCount[NPC.type] = 4;
    }
    public override void SetDefaults()
    {
        NPC.damage = 95;
        NPC.lifeMax = 600;
        NPC.defense = 26;
        NPC.width = 60;
        NPC.aiStyle = 1;
        NPC.value = 0f;
        NPC.height = 42;
        NPC.knockBackResist = 0.3f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.buffImmune[BuffID.Poisoned] = true;
        NPC.buffImmune[BuffID.Confused] = true;

        suicideTimer = 0;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.35f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void OnKill()
    {
        for (var k = 0; k < 2; k++)
        {
            NPC.NewNPC(NPC.GetSpawnSourceForNaturalSpawn(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<NPCs.DarkMatterSlime>(), 0);
        }
    }

    public override void AI()
    {
        if (NPC.life <= NPC.lifeMax / 4)
        {
            bool explode = false;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC scannedNPC = Main.npc[i];
                if (scannedNPC.type == ModContent.NPCType<NPCs.Bosses.ArmageddonSlime>())
                {
                    if (Vector2.Distance(NPC.Center, scannedNPC.Center) < 5000)
                    {
                        explode = true;
                        NPC.value = 0;
                    }
                }
            }

            if (explode)
            {
                NPC.life = NPC.lifeMax / 4;
                NPC.dontTakeDamage = true;
                NPC.chaseable = false;
                NPC.wet = false;
                if (suicideTimer < 0)
                    suicideTimer = 0;
                else
                    suicideTimer--;

                if (Main.expertMode && flashCounter == 4 && suicideTimer >= 25 && suicideTimer < 30 && Math.Abs(NPC.Center.X - Main.player[NPC.target].Center.X) > 150)
                {
                    NPC.TargetClosest(true);
                    NPC.velocity = new Vector2(8f * NPC.direction, -6f);
                }
                else if (suicideTimer <= 30)
                {
                    NPC.ai[0] = -30;
                    NPC.aiAction = 1;
                }

                if ((flashCounter == 0 || flashCounter == 2 || flashCounter == 4) && NPC.color.R != 255)
                    ToRed();

                if ((flashCounter == 1 || flashCounter == 3) && NPC.color.R != 0)
                    ToDefault();

                if ((NPC.color.R == 255 || NPC.color.R == 0) && suicideTimer == 0)
                {
                    flashCounter += 1;
                    suicideTimer = 30;
                }

                if (flashCounter >= 5)
                {
                    NPC.color = new Color(255, 0, 0);
                    Explode();
                }
            }
            else
            {
                if (NPC.color.R != 0)
                    ToDefault();
                NPC.dontTakeDamage = false;
                NPC.chaseable = true;
            }
        }
    }
    public void ToRed()
    {
        if (NPC.color.R < 255)
            NPC.color.R += 15;
    }
    public void ToDefault()
    {
        if (NPC.color.R > 0)
            NPC.color.R -= 15;
    }
    public override void FindFrame(int frameHeight)
    {
        var num2 = 0;
        if (NPC.aiAction == 0)
        {
            if (NPC.velocity.Y < 0f)
            {
                num2 = 2;
            }
            else if (NPC.velocity.Y > 0f)
            {
                num2 = 3;
            }
            else if (NPC.velocity.X != 0f)
            {
                num2 = 1;
            }
            else
            {
                num2 = 0;
            }
        }
        else if (NPC.aiAction == 1)
        {
            num2 = 4;
        }
        NPC.frameCounter += 1.0;
        if (num2 > 0)
        {
            NPC.frameCounter += 1.0;
        }
        if (num2 == 4)
        {
            NPC.frameCounter += 1.0;
        }
        if (NPC.frameCounter >= 8.0)
        {
            NPC.frame.Y = NPC.frame.Y + frameHeight;
            NPC.frameCounter = 0.0;
        }
        if (NPC.frame.Y >= frameHeight * Main.npcFrameCount[NPC.type])
        {
            NPC.frame.Y = 0;
        }
    }
    public void Explode()
    {
        SoundEngine.PlaySound(SoundID.NPCKilled, NPC.position, 14);

        for (int i = 0; i < 2; i++)
        {
            int randomSize = Main.rand.Next(1, 4) / 2;
            int num161 = Gore.NewGore(new Vector2(NPC.position.X, NPC.position.Y), default(Vector2), Main.rand.Next(61, 64));
            Gore gore30 = Main.gore[num161];
            Gore gore40 = gore30;
            gore40.velocity *= 0.3f;
            gore40.scale *= randomSize;
            Main.gore[num161].velocity.X += Main.rand.Next(-1, 2);
            Main.gore[num161].velocity.Y += Main.rand.Next(-1, 2);
        }
        int bomb = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center, Vector2.Zero, ProjectileID.Grenade, 50, 3f);
        Main.projectile[bomb].timeLeft = 1;
        Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center, new Vector2(0, -5f), ModContent.ProjectileType<Projectiles.DarkGeyser>(), NPC.damage / 3, 1f);
        for (int i = 0; i < 9; i++)
        {
            int rand = Main.rand.Next(-10, 11);
            Vector2 velocity = new Vector2(0, -5f).RotatedBy(MathHelper.ToRadians(rand));
            int cinder = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center, velocity, ModContent.ProjectileType<Projectiles.DarkCinder>(), NPC.damage / 4, 0.5f);

        }
        NPC.NPCLoot();
        NPC.active = false;
    }
    public override void OnHitPlayer(Player target, int damage, bool crit)
    {
        target.AddBuff(ModContent.BuffType<Buffs.DarkInferno>(), 300);
    }
}