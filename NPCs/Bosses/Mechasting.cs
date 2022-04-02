using System;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Potions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;

namespace ExxoAvalonOrigins.NPCs.Bosses;

public class Mechasting : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Mechasting");
        Main.npcFrameCount[NPC.type] = 3;
    }

    public override void SetDefaults()
    {
        NPC.aiStyle = -1;
        NPC.npcSlots = 175;
        NPC.height = 174;
        NPC.width = 88;
        NPC.knockBackResist = 0f;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.value = 50000;
        NPC.timeLeft = 22500;
        NPC.damage = 142;
        NPC.defense = 65;
        NPC.HitSound = SoundID.NPCHit4;
        NPC.DeathSound = SoundID.NPCDeath14;
        NPC.boss = true;
        NPC.lifeMax = 82000;
        NPC.scale = 1.2f;
        Music = ExxoAvalonOrigins.Mod.MusicMod == null ? MusicID.Boss3 : MusicID.Boss3; //MusicLoader.GetMusicSlot(ExxoAvalonOrigins.Mod.MusicMod, "Sounds/Music/Mechasting");
        //bossBag = ModContent.ItemType<Items.BossBags.MechastingBossBag>();

    }
    public override void BossLoot(ref string name, ref int potionType)
    {
        potionType = ModContent.ItemType<ElixirofLife>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.65f);
    }
    public override void AI()
    {
        NPC.TargetClosest(true);
        if (Main.player[NPC.target].dead)
        {
            NPC.velocity.Y = NPC.velocity.Y - 0.04f;
            if (NPC.timeLeft > 10)
            {
                NPC.timeLeft = 10;
                return;
            }
        }
        // ai phase 1
        if (NPC.ai[3] == 0)
        {
            NPC.ai[0]++; // ai phase counter
            if (Main.player[NPC.target].position.X < NPC.position.X)
            {
                if (NPC.velocity.X > -8) NPC.velocity.X -= 0.22f;
            }
            if (Main.player[NPC.target].position.X > NPC.position.X)
            {
                if (NPC.velocity.X < 8) NPC.velocity.X += 0.22f;
            }
            if (Main.player[NPC.target].position.Y < NPC.position.Y + 300)
            {
                if (NPC.velocity.Y < 0)
                {
                    if (NPC.velocity.Y > -4) NPC.velocity.Y -= 0.8f;
                }
                else NPC.velocity.Y -= 0.6f;
                if (NPC.velocity.Y < -4) NPC.velocity.Y = -4;
            }
            if (Main.player[NPC.target].position.Y > NPC.position.Y + 300)
            {
                if (NPC.velocity.Y > 0)
                {
                    if (NPC.velocity.Y < 4) NPC.velocity.Y += 0.8f;
                }
                else NPC.velocity.Y += 0.6f;
                if (NPC.velocity.Y > 4) NPC.velocity.Y = 4;
            }
            NPC.ai[2]++;
            // fire laser
            if (NPC.ai[2] > 15)
            {
                float Speed = 9f;
                Vector2 vector8 = new Vector2(NPC.Center.X, NPC.position.Y + NPC.height - 10);
                int damage = 90;
                SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.position.Y, 33);
                Vector2 offset = new Vector2(NPC.Center.X + Main.rand.Next(5) * NPC.direction, NPC.Center.Y + Main.rand.Next(5, 10));
                float rotation = (float)Math.Atan2(NPC.Center.Y - offset.Y, NPC.Center.X - offset.X);
                int num54 = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), ProjectileID.DeathLaser, damage, 0f, 0);
                //Main.projectile[num54].notReflect = true;
                NPC.ai[2] = 0;
            }
            if (NPC.ai[0] > 540)
            {
                NPC.ai[0] = 0;
                NPC.ai[3] = 1;
                NPC.ai[2] = 0;
            }
        }
        // ai phase 2
        else if (NPC.ai[3] == 1)
        {
            NPC.ai[2]++; // ai phase counter
            NPC.ai[1]++; // movement and stinger probe counter
            // normal movement 
            if (NPC.ai[1] < 300)
            {
                if (Main.player[NPC.target].position.X < NPC.position.X)
                {
                    if (NPC.velocity.X > -8) NPC.velocity.X -= 0.22f;
                }
                if (Main.player[NPC.target].position.X > NPC.position.X)
                {
                    if (NPC.velocity.X < 8) NPC.velocity.X += 0.22f;
                }
                if (Main.player[NPC.target].position.Y < NPC.position.Y + 300)
                {
                    if (NPC.velocity.Y < 0)
                    {
                        if (NPC.velocity.Y > -4) NPC.velocity.Y -= 0.8f;
                    }
                    else NPC.velocity.Y -= 0.6f;
                    if (NPC.velocity.Y < -4) NPC.velocity.Y = -4;
                }
                if (Main.player[NPC.target].position.Y > NPC.position.Y + 300)
                {
                    if (NPC.velocity.Y > 0)
                    {
                        if (NPC.velocity.Y < 4) NPC.velocity.Y += 0.8f;
                    }
                    else NPC.velocity.Y += 0.6f;
                    if (NPC.velocity.Y > 4) NPC.velocity.Y = 4;
                }
            }
            NPC.ai[0]++; // stinger counter
            // fire a spread of stingers at the closest player
            if (NPC.ai[0] >= 90)
            {
                float speed = 12f;
                Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
                int damage = 60;
                int type = ModContent.ProjectileType<Projectiles.Mechastinger>();
                float rotation = (float)Math.Atan2(NPC.Center.Y - Main.player[NPC.target].Center.Y, NPC.Center.X - Main.player[NPC.target].Center.X);
                int num54;
                float f = 0f;
                if (NPC.ai[0] >= 150)
                {
                    while (f <= .2f)
                    {
                        num54 = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), vector8.X, vector8.Y, (float)((Math.Cos(rotation + f) * speed) * -1), (float)((Math.Sin(rotation + f) * speed) * -1), type, damage, 0f, NPC.target);
                        Main.projectile[num54].timeLeft = 600;
                        Main.projectile[num54].tileCollide = false;
                        //Main.projectile[num54].notReflect = true;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, num54);
                        }
                        num54 = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), vector8.X, vector8.Y, (float)((Math.Cos(rotation - f) * speed) * -1), (float)((Math.Sin(rotation - f) * speed) * -1), type, damage, 0f, NPC.target);
                        Main.projectile[num54].timeLeft = 600;
                        Main.projectile[num54].tileCollide = false;
                        //Main.projectile[num54].notReflect = true;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, num54);
                        }
                        f += .04f;
                    }
                    NPC.ai[0] = 0;
                }
            }
            // dash at the player
            if (NPC.ai[1] >= 300)
            {
                NPC.velocity.X *= 0.98f;
                NPC.velocity.Y *= 0.98f;
                Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
                if ((NPC.velocity.X < 2f) && (NPC.velocity.X > -2f) && (NPC.velocity.Y < 2f) && (NPC.velocity.Y > -2f))
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), (vector8.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
                    NPC.velocity.X = (float)(Math.Cos(rotation) * 25) * -1;
                    NPC.velocity.Y = (float)(Math.Sin(rotation) * 25) * -1;
                }
                NPC.ai[1] = 0;
            }
            // spawn stinger probes
            if (NPC.ai[1] % 70 == 0)
            {
                NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<StingerProbe>(), NPC.target);
            }
            if (NPC.ai[2] > 700)
            {
                NPC.ai[2] = 0;
                NPC.ai[3] = 2;
            }
        }
        // ai phase 3
        if (NPC.ai[3] == 2)
        {
            // fire rockets
            NPC.velocity *= 0f;
            NPC.noGravity = true;
            NPC.ai[1]++; // rocket counter
            if (NPC.ai[1] > 90 && NPC.ai[1] < 360 && NPC.ai[1] % 25 == 0)
            {
                float rotation = (float)Math.Atan2(NPC.Center.Y - Main.player[NPC.target].Center.Y, NPC.Center.X - Main.player[NPC.target].Center.X);
                float f = 0f; // degrees; 3.6f is a full 360 degrees
                float speed = 9f; // velocity of the projectile to be fired
                int p;
                while (f < 0.2f) // less than 20 degrees
                {
                    p = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, (float)((Math.Cos(rotation + f) * speed) * -1), (float)((Math.Sin(rotation + f) * speed) * -1), ModContent.ProjectileType<Projectiles.HomingRocket>(), 80, 0f, NPC.target);
                    Main.projectile[p].timeLeft = 600;
                    Main.projectile[p].friendly = false;
                    //Main.projectile[p].notReflect = true;
                    //Main.projectile[p].bombPlayer = true;
                    Main.projectile[p].hostile = true;
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                    }

                    p = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, (float)((Math.Cos(rotation - f) * speed) * -1), (float)((Math.Sin(rotation - f) * speed) * -1), ModContent.ProjectileType<Projectiles.HomingRocket>(), 80, 0f, NPC.target);
                    Main.projectile[p].timeLeft = 600;
                    Main.projectile[p].friendly = false;
                    //Main.projectile[p].notReflect = true;
                    //Main.projectile[p].bombPlayer = true;
                    Main.projectile[p].hostile = true;
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                    }
                    f += .2f;
                }
            }
            if (NPC.ai[1] == 360)
            {
                NPC.ai[0] = 0;
                NPC.ai[1] = 0;
                NPC.ai[3] = 3;
            }
        }
        // ai phase 4
        if (NPC.ai[3] == 3)
        {
            NPC.ai[2]++; // ai phase counter
            if (Main.player[NPC.target].position.X < NPC.position.X)
            {
                if (NPC.velocity.X > -8) NPC.velocity.X -= 0.22f;
            }
            if (Main.player[NPC.target].position.X > NPC.position.X)
            {
                if (NPC.velocity.X < 8) NPC.velocity.X += 0.22f;
            }
            if (Main.player[NPC.target].position.Y < NPC.position.Y + 300)
            {
                if (NPC.velocity.Y < 0)
                {
                    if (NPC.velocity.Y > -4) NPC.velocity.Y -= 0.8f;
                }
                else NPC.velocity.Y -= 0.6f;
                if (NPC.velocity.Y < -4) NPC.velocity.Y = -4;
            }
            if (Main.player[NPC.target].position.Y > NPC.position.Y + 300)
            {
                if (NPC.velocity.Y > 0)
                {
                    if (NPC.velocity.Y < 4) NPC.velocity.Y += 0.8f;
                }
                else NPC.velocity.Y += 0.6f;
                if (NPC.velocity.Y > 4) NPC.velocity.Y = 4;
            }
            NPC.ai[1]++; // electric bolt counter
            if (NPC.ai[1] >= 240 && NPC.ai[1] <= 300)
            {
                float rotation = (float)Math.Atan2(NPC.Center.Y - Main.player[NPC.target].Center.Y, NPC.Center.X - Main.player[NPC.target].Center.X);
                float f = 0f; // degrees; 3.6f is a full 360 degrees
                float speed = 9f; // the velocity of the projectile to be shot
                if (Main.expertMode)
                {
                    speed = 15f;
                }
                int p;
                #region electric bolt attack
                if (NPC.ai[1] % 60 == 0)
                {
                    float increment = Main.expertMode ? 0.225f : 0.45f;
                    while (f <= 3.6f)
                    {
                        // above the boss
                        p = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, (float)((Math.Cos(rotation + f) * speed) * -1), (float)((Math.Sin(rotation + f) * speed) * -1), ModContent.ProjectileType<Projectiles.ElectricBolt>(), 80, 0f, NPC.target);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        //Main.projectile[p].notReflect = true;
                        Main.projectile[p].hostile = true;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }
                        // below the boss
                        p = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, (float)((Math.Cos(rotation - f) * speed) * -1), (float)((Math.Sin(rotation - f) * speed) * -1), ModContent.ProjectileType<Projectiles.ElectricBolt>(), 80, 0f, NPC.target);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        //Main.projectile[p].notReflect = true;
                        Main.projectile[p].hostile = true;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, null, p);
                        }
                        f += increment;
                    }
                }
                #endregion
                if (NPC.ai[1] == 300)
                {
                    NPC.ai[1] = 0;
                }
            }
            if (NPC.ai[2] > 900)
            {
                NPC.ai[0] = 0;
                NPC.ai[1] = 0;
                NPC.ai[2] = 0;
                NPC.ai[3] = 0;
            }
        }
    }
    public override void OnKill()
    {
        if (!ExxoAvalonOriginsWorld.downedMechasting)
            ExxoAvalonOriginsWorld.downedMechasting = true;
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        if (!Main.expertMode)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoulofDelight>(), 1, 20, 40));
            npcLoot.Add(ItemDropRule.OneFromOptions(1, new int[] { ModContent.ItemType<Items.Accessories.StingerPack>(), ModContent.ItemType<Items.Weapons.Magic.Mechazapinator>(), ModContent.ItemType<Items.Weapons.Ranged.HeatSeeker>() }));
        }
        npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Items.BossBags.MechastingBossBag>()));
    }
    public override void FindFrame(int frameHeight)
    {
        NPC.spriteDirection = NPC.direction;
        NPC.rotation = NPC.velocity.X * 0.03f;
        NPC.frameCounter++;
        if (NPC.frameCounter < 3.0)
        {
            NPC.frame.Y = 0;
        }
        else if (NPC.frameCounter < 6.0)
        {
            NPC.frame.Y = frameHeight;
        }
        else if (NPC.frameCounter < 9.0)
        {
            NPC.frame.Y = frameHeight * 2;
        }
        else if (NPC.frameCounter < 12.0)
        {
            NPC.frame.Y = frameHeight;
        }
        else
        {
            NPC.frameCounter = 0.0;
        }
    }
}
