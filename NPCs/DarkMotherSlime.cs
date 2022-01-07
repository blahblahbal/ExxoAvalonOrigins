using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
    public class DarkMotherSlime : ModNPC
    {
        int suicideTimer;
        int flashCounter;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Mother Slime");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.damage = 95;
            npc.lifeMax = 600;
            npc.defense = 26;
            npc.width = 60;
            npc.aiStyle = 1;
            npc.value = 0f;
            npc.height = 42;
            npc.knockBackResist = 0.3f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Confused] = true;

            suicideTimer = 0;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.35f);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void NPCLoot()
        {
            for (var k = 0; k < 2; k++)
            {
                if (NPC.AnyNPCs(ModContent.NPCType<Bosses.ArmageddonSlime>()))
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<NPCs.DarkMatterSlime>(), 0);
                }
                else
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<NPCs.DarkMatterSlime>(), 0);
                }
            }
        }

        public override void AI()
        {
            if (npc.life <= npc.lifeMax / 4)
            {
                bool explode = false;
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC scannedNPC = Main.npc[i];
                    if (scannedNPC.type == ModContent.NPCType<NPCs.Bosses.ArmageddonSlime>())
                    {
                        if (Vector2.Distance(npc.Center, scannedNPC.Center) < 5000)
                        {
                            explode = true;
                            npc.value = 0;
                        }
                    }
                }

                if (explode)
                {
                    npc.life = npc.lifeMax / 4;
                    npc.dontTakeDamage = true;
                    npc.chaseable = false;
                    npc.wet = false;
                    if (suicideTimer < 0)
                        suicideTimer = 0;
                    else
                        suicideTimer--;

                    if (Main.expertMode && flashCounter == 4 && suicideTimer >= 25 && suicideTimer < 30 && Math.Abs(npc.Center.X - Main.player[npc.target].Center.X) > 150)
                    {
                        npc.TargetClosest(true);
                        npc.velocity = new Vector2(8f * npc.direction, -6f);
                    }
                    else if (suicideTimer <= 30)
                    {
                        npc.ai[0] = -30;
                        npc.aiAction = 1;
                    }

                    if ((flashCounter == 0 || flashCounter == 2 || flashCounter == 4) && npc.color.R != 255)
                        ToRed();

                    if ((flashCounter == 1 || flashCounter == 3) && npc.color.R != 0)
                        ToDefault();

                    if ((npc.color.R == 255 || npc.color.R == 0) && suicideTimer == 0)
                    {
                        flashCounter += 1;
                        suicideTimer = 30;
                    }

                    if (flashCounter >= 5)
                    {
                        npc.color = new Color(255, 0, 0);
                        Explode();
                    }
                }
                else
                {
                    if (npc.color.R != 0)
                        ToDefault();
                    npc.dontTakeDamage = false;
                    npc.chaseable = true;
                }
            }
        }
        public void ToRed()
        {
            if (npc.color.R < 255)
                npc.color.R += 15;
        }
        public void ToDefault()
        {
            if (npc.color.R > 0)
                npc.color.R -= 15;
        }
        public override void FindFrame(int frameHeight)
        {
            var num2 = 0;
            if (npc.aiAction == 0)
            {
                if (npc.velocity.Y < 0f)
                {
                    num2 = 2;
                }
                else if (npc.velocity.Y > 0f)
                {
                    num2 = 3;
                }
                else if (npc.velocity.X != 0f)
                {
                    num2 = 1;
                }
                else
                {
                    num2 = 0;
                }
            }
            else if (npc.aiAction == 1)
            {
                num2 = 4;
            }
            npc.frameCounter += 1.0;
            if (num2 > 0)
            {
                npc.frameCounter += 1.0;
            }
            if (num2 == 4)
            {
                npc.frameCounter += 1.0;
            }
            if (npc.frameCounter >= 8.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
            }
        }
        public void Explode()
        {
            Main.PlaySound(SoundID.NPCKilled, npc.position, 14);

            for (int i = 0; i < 2; i++)
            {
                int randomSize = Main.rand.Next(1, 4) / 2;
                int num161 = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y), default(Vector2), Main.rand.Next(61, 64));
                Gore gore30 = Main.gore[num161];
                Gore gore40 = gore30;
                gore40.velocity *= 0.3f;
                gore40.scale *= randomSize;
                Main.gore[num161].velocity.X += Main.rand.Next(-1, 2);
                Main.gore[num161].velocity.Y += Main.rand.Next(-1, 2);
            }
            int bomb = Projectile.NewProjectile(npc.Center, Vector2.Zero, ProjectileID.Grenade, 50, 3f);
            Main.projectile[bomb].timeLeft = 1;
            Projectile.NewProjectile(npc.Center, new Vector2(0, -5f), ModContent.ProjectileType<Projectiles.DarkGeyser>(), npc.damage / 3, 1f);
            for (int i = 0; i < 9; i++)
            {
                int rand = Main.rand.Next(-10, 11);
                Vector2 velocity = new Vector2(0, -5f).RotatedBy(MathHelper.ToRadians(rand));
                int cinder = Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.DarkCinder>(), npc.damage / 4, 0.5f);

            }
            npc.NPCLoot();
            npc.active = false;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Buffs.DarkInferno>(), 300);
        }
    }
}
