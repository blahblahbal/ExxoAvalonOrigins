using System;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Potions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs.Bosses
{
    public class Mechasting : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechasting");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.npcSlots = 175;
            npc.height = 174;
            npc.width = 88;
            npc.knockBackResist = 0f;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.value = 50000;
            npc.timeLeft = 22500;
            npc.damage = 142;
            npc.defense = 65;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.boss = true;
            npc.lifeMax = 82000;
            npc.scale = 1.2f;
            bossBag = ModContent.ItemType<Items.BossBags.MechastingBossBag>();

        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ModContent.ItemType<ElixirofLife>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f);
            npc.damage = (int)(npc.damage * 0.65f);
        }
        public override void AI()
        {
            npc.TargetClosest(true);
            if (Main.player[npc.target].dead)
            {
                npc.velocity.Y = npc.velocity.Y - 0.04f;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                    return;
                }
            }
            // ai phase 1
            if (npc.ai[3] == 0)
            {
                npc.ai[0]++; // ai phase counter
                if (Main.player[npc.target].position.X < npc.position.X)
                {
                    if (npc.velocity.X > -8) npc.velocity.X -= 0.22f;
                }
                if (Main.player[npc.target].position.X > npc.position.X)
                {
                    if (npc.velocity.X < 8) npc.velocity.X += 0.22f;
                }
                if (Main.player[npc.target].position.Y < npc.position.Y + 300)
                {
                    if (npc.velocity.Y < 0)
                    {
                        if (npc.velocity.Y > -4) npc.velocity.Y -= 0.8f;
                    }
                    else npc.velocity.Y -= 0.6f;
                    if (npc.velocity.Y < -4) npc.velocity.Y = -4;
                }
                if (Main.player[npc.target].position.Y > npc.position.Y + 300)
                {
                    if (npc.velocity.Y > 0)
                    {
                        if (npc.velocity.Y < 4) npc.velocity.Y += 0.8f;
                    }
                    else npc.velocity.Y += 0.6f;
                    if (npc.velocity.Y > 4) npc.velocity.Y = 4;
                }
                npc.ai[2]++;
                // fire laser
                if (npc.ai[2] > 15)
                {
                    float Speed = 9f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 90;
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 33);
                    Vector2 offset = new Vector2(npc.Center.X + Main.rand.Next(5) * npc.direction, npc.Center.Y + Main.rand.Next(5, 10));
                    float rotation = (float)Math.Atan2(npc.Center.Y - offset.Y, npc.Center.X - offset.X);
                    int num54 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), ProjectileID.DeathLaser, damage, 0f, 0);
                    //Main.projectile[num54].notReflect = true;
                    npc.ai[2] = 0;
                }
                if (npc.ai[0] > 540)
                {
                    npc.ai[0] = 0;
                    npc.ai[3] = 1;
                    npc.ai[2] = 0;
                }
            }
            // ai phase 2
            else if (npc.ai[3] == 1)
            {
                npc.ai[2]++; // ai phase counter
                npc.ai[1]++; // movement and stinger probe counter
                // normal movement 
                if (npc.ai[1] < 300)
                {
                    if (Main.player[npc.target].position.X < npc.position.X)
                    {
                        if (npc.velocity.X > -8) npc.velocity.X -= 0.22f;
                    }
                    if (Main.player[npc.target].position.X > npc.position.X)
                    {
                        if (npc.velocity.X < 8) npc.velocity.X += 0.22f;
                    }
                    if (Main.player[npc.target].position.Y < npc.position.Y + 300)
                    {
                        if (npc.velocity.Y < 0)
                        {
                            if (npc.velocity.Y > -4) npc.velocity.Y -= 0.8f;
                        }
                        else npc.velocity.Y -= 0.6f;
                        if (npc.velocity.Y < -4) npc.velocity.Y = -4;
                    }
                    if (Main.player[npc.target].position.Y > npc.position.Y + 300)
                    {
                        if (npc.velocity.Y > 0)
                        {
                            if (npc.velocity.Y < 4) npc.velocity.Y += 0.8f;
                        }
                        else npc.velocity.Y += 0.6f;
                        if (npc.velocity.Y > 4) npc.velocity.Y = 4;
                    }
                }
                npc.ai[0]++; // stinger counter
                             // fire a spread of stingers at the closest player
                if (npc.ai[0] >= 90)
                {
                    float speed = 12f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                    int damage = 60;
                    int type = ModContent.ProjectileType<Projectiles.Mechastinger>();
                    float rotation = (float)Math.Atan2(npc.Center.Y - Main.player[npc.target].Center.Y, npc.Center.X - Main.player[npc.target].Center.X);
                    int num54;
                    float f = 0f;
                    if (npc.ai[0] >= 150)
                    {
                        while (f <= .2f)
                        {
                            num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation + f) * speed) * -1), (float)((Math.Sin(rotation + f) * speed) * -1), type, damage, 0f, npc.target);
                            Main.projectile[num54].timeLeft = 600;
                            Main.projectile[num54].tileCollide = false;
                            //Main.projectile[num54].notReflect = true;
                            if (Main.netMode != NetmodeID.SinglePlayer)
                            {
                                NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, num54);
                            }
                            num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation - f) * speed) * -1), (float)((Math.Sin(rotation - f) * speed) * -1), type, damage, 0f, npc.target);
                            Main.projectile[num54].timeLeft = 600;
                            Main.projectile[num54].tileCollide = false;
                            //Main.projectile[num54].notReflect = true;
                            if (Main.netMode != NetmodeID.SinglePlayer)
                            {
                                NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, num54);
                            }
                            f += .04f;
                        }
                        npc.ai[0] = 0;
                    }
                }
                // dash at the player
                if (npc.ai[1] >= 300)
                {
                    npc.velocity.X *= 0.98f;
                    npc.velocity.Y *= 0.98f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                    if ((npc.velocity.X < 2f) && (npc.velocity.X > -2f) && (npc.velocity.Y < 2f) && (npc.velocity.Y > -2f))
                    {
                        float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                        npc.velocity.X = (float)(Math.Cos(rotation) * 25) * -1;
                        npc.velocity.Y = (float)(Math.Sin(rotation) * 25) * -1;
                    }
                    npc.ai[1] = 0;
                }
                // spawn stinger probes
                if (npc.ai[1] % 70 == 0)
                {
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<StingerProbe>(), npc.target);
                }
                if (npc.ai[2] > 700)
                {
                    npc.ai[2] = 0;
                    npc.ai[3] = 2;
                }
            }
            // ai phase 3
            if (npc.ai[3] == 2)
            {
                // fire rockets
                npc.velocity *= 0f;
                npc.noGravity = true;
                npc.ai[1]++; // rocket counter
                if (npc.ai[1] > 90 && npc.ai[1] < 360 && npc.ai[1] % 25 == 0)
                {
                    float rotation = (float)Math.Atan2(npc.Center.Y - Main.player[npc.target].Center.Y, npc.Center.X - Main.player[npc.target].Center.X);
                    float f = 0f; // degrees; 3.6f is a full 360 degrees
                    float speed = 9f; // velocity of the projectile to be fired
                    int p;
                    while (f < 0.2f) // less than 20 degrees
                    {
                        p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation + f) * speed) * -1), (float)((Math.Sin(rotation + f) * speed) * -1), ModContent.ProjectileType<Projectiles.HomingRocket>(), 80, 0f, npc.target);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        //Main.projectile[p].notReflect = true;
                        //Main.projectile[p].bombPlayer = true;
                        Main.projectile[p].hostile = true;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }

                        p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation - f) * speed) * -1), (float)((Math.Sin(rotation - f) * speed) * -1), ModContent.ProjectileType<Projectiles.HomingRocket>(), 80, 0f, npc.target);
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
                if (npc.ai[1] == 360)
                {
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[3] = 3;
                }
            }
            // ai phase 4
            if (npc.ai[3] == 3)
            {
                npc.ai[2]++; // ai phase counter
                if (Main.player[npc.target].position.X < npc.position.X)
                {
                    if (npc.velocity.X > -8) npc.velocity.X -= 0.22f;
                }
                if (Main.player[npc.target].position.X > npc.position.X)
                {
                    if (npc.velocity.X < 8) npc.velocity.X += 0.22f;
                }
                if (Main.player[npc.target].position.Y < npc.position.Y + 300)
                {
                    if (npc.velocity.Y < 0)
                    {
                        if (npc.velocity.Y > -4) npc.velocity.Y -= 0.8f;
                    }
                    else npc.velocity.Y -= 0.6f;
                    if (npc.velocity.Y < -4) npc.velocity.Y = -4;
                }
                if (Main.player[npc.target].position.Y > npc.position.Y + 300)
                {
                    if (npc.velocity.Y > 0)
                    {
                        if (npc.velocity.Y < 4) npc.velocity.Y += 0.8f;
                    }
                    else npc.velocity.Y += 0.6f;
                    if (npc.velocity.Y > 4) npc.velocity.Y = 4;
                }
                npc.ai[1]++; // electric bolt counter
                if (npc.ai[1] >= 240 && npc.ai[1] <= 300)
                {
                    float rotation = (float)Math.Atan2(npc.Center.Y - Main.player[npc.target].Center.Y, npc.Center.X - Main.player[npc.target].Center.X);
                    float f = 0f; // degrees; 3.6f is a full 360 degrees
                    float speed = 9f; // the velocity of the projectile to be shot
                    if (Main.expertMode)
                    {
                        speed = 15f;
                    }
                    int p;
                    if (npc.ai[1] % 60 == 0)
                    {
                        while (f <= 3.6f)
                        {
                            // above the boss
                            p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation + f) * speed) * -1), (float)((Math.Sin(rotation + f) * speed) * -1), ModContent.ProjectileType<Projectiles.ElectricBolt>(), 80, 0f, npc.target);
                            Main.projectile[p].timeLeft = 600;
                            Main.projectile[p].friendly = false;
                            //Main.projectile[p].notReflect = true;
                            Main.projectile[p].hostile = true;
                            if (Main.netMode != NetmodeID.SinglePlayer)
                            {
                                NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                            }
                            // below the boss
                            p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation - f) * speed) * -1), (float)((Math.Sin(rotation - f) * speed) * -1), ModContent.ProjectileType<Projectiles.ElectricBolt>(), 80, 0f, npc.target);
                            Main.projectile[p].timeLeft = 600;
                            Main.projectile[p].friendly = false;
                            //Main.projectile[p].notReflect = true;
                            Main.projectile[p].hostile = true;
                            if (Main.netMode != NetmodeID.SinglePlayer)
                            {
                                NetMessage.SendData(MessageID.SyncProjectile, -1, -1, null, p);
                            }
                            f += .45f;
                        }
                    }
                    if (npc.ai[1] == 300)
                    {
                        npc.ai[1] = 0;
                    }
                }
                if (npc.ai[2] > 900)
                {
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                    npc.ai[3] = 0;
                }
            }
        }
        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SoulofDelight>(), Main.rand.Next(20, 41), false, 0, false);
                int rn = Main.rand.Next(4);
                if (rn == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Accessories.StingerPack>(), 1, false, -1, false);
                }
                if (rn == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Weapons.Magic.Mechazapinator>(), 1, false, -1, false);
                }
                if (rn == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Weapons.Ranged.HeatSeeker>(), 1, false, -1, false);
                }
            }

            if (!ExxoAvalonOriginsWorld.downedMechasting)
                ExxoAvalonOriginsWorld.downedMechasting = true;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.rotation = npc.velocity.X * 0.03f;
            npc.frameCounter++;
            if (npc.frameCounter < 3.0)
            {
                npc.frame.Y = 0;
            }
            else if (npc.frameCounter < 6.0)
            {
                npc.frame.Y = frameHeight;
            }
            else if (npc.frameCounter < 9.0)
            {
                npc.frame.Y = frameHeight * 2;
            }
            else if (npc.frameCounter < 12.0)
            {
                npc.frame.Y = frameHeight;
            }
            else
            {
                npc.frameCounter = 0.0;
            }
        }
    }
}
