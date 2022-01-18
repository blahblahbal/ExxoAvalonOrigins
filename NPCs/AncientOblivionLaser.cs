using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class AncientOblivionLaser : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Oblivion Laser");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.damage = 60;
            npc.noTileCollide = true;
            npc.lifeMax = 45000;
            npc.defense = 20;
            npc.noGravity = true;
            npc.width = 52;
            npc.aiStyle = -1;
            npc.npcSlots = 1f;
            npc.value = 0f;
            npc.timeLeft = 750;
            npc.height = 52;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().noOneHitKill = true;
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart, Main.rand.Next(3, 6), false, 0, false);
            if (Main.expertMode) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart, Main.rand.Next(5, 8), false, 0, false);
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.35f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.3f);
        }
        public override void AI()
        {
            npc.spriteDirection = -(int)npc.ai[0];
            if (!Main.npc[(int)npc.ai[1]].active || !(Main.npc[(int)npc.ai[1]].type == ModContent.NPCType<AncientOblivionHead1>() || Main.npc[(int)npc.ai[1]].type == ModContent.NPCType<AncientOblivionHead2>()))
            {
                npc.ai[2] += 10f;
                if (npc.ai[2] > 50f || Main.netMode != NetmodeID.Server)
                {
                    npc.life = -1;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
            }
            if (npc.ai[2] == 0f || npc.ai[2] == 3f)
            {
                if (Main.npc[(int)npc.ai[1]].ai[1] == 3f && npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                }
                if (Main.npc[(int)npc.ai[1]].ai[1] != 0f)
                {
                    npc.localAI[0] += 3f;
                    if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y - 100f)
                    {
                        if (npc.velocity.Y > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y * 0.96f;
                        }
                        npc.velocity.Y = npc.velocity.Y - 0.07f;
                        if (npc.velocity.Y > 6f)
                        {
                            npc.velocity.Y = 6f;
                        }
                    }
                    else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 100f)
                    {
                        if (npc.velocity.Y < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y * 0.96f;
                        }
                        npc.velocity.Y = npc.velocity.Y + 0.07f;
                        if (npc.velocity.Y < -6f)
                        {
                            npc.velocity.Y = -6f;
                        }
                    }
                    if (npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 120f * npc.ai[0])
                    {
                        if (npc.velocity.X > 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.96f;
                        }
                        npc.velocity.X = npc.velocity.X - 0.1f;
                        if (npc.velocity.X > 8f)
                        {
                            npc.velocity.X = 8f;
                        }
                    }
                    if (npc.position.X + npc.width / 2 < Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 120f * npc.ai[0])
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.96f;
                        }
                        npc.velocity.X = npc.velocity.X + 0.1f;
                        if (npc.velocity.X < -8f)
                        {
                            npc.velocity.X = -8f;
                        }
                    }
                }
                else
                {
                    npc.ai[3] += 1f;
                    if (npc.ai[3] >= 800f)
                    {
                        npc.ai[2] += 1f;
                        npc.ai[3] = 0f;
                        npc.netUpdate = true;
                    }
                    if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y - 100f)
                    {
                        if (npc.velocity.Y > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y * 0.96f;
                        }
                        npc.velocity.Y = npc.velocity.Y - 0.1f;
                        if (npc.velocity.Y > 3f)
                        {
                            npc.velocity.Y = 3f;
                        }
                    }
                    else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 100f)
                    {
                        if (npc.velocity.Y < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y * 0.96f;
                        }
                        npc.velocity.Y = npc.velocity.Y + 0.1f;
                        if (npc.velocity.Y < -3f)
                        {
                            npc.velocity.Y = -3f;
                        }
                    }
                    if (npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 180f * npc.ai[0])
                    {
                        if (npc.velocity.X > 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.96f;
                        }
                        npc.velocity.X = npc.velocity.X - 0.14f;
                        if (npc.velocity.X > 8f)
                        {
                            npc.velocity.X = 8f;
                        }
                    }
                    if (npc.position.X + npc.width / 2 < Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 180f * npc.ai[0])
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.96f;
                        }
                        npc.velocity.X = npc.velocity.X + 0.14f;
                        if (npc.velocity.X < -8f)
                        {
                            npc.velocity.X = -8f;
                        }
                    }
                }
                npc.localAI[0] += 1f;
                if (npc.localAI[0] >= 180f)
                {
                    var num627 = 12f;
                    var vector71 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height / 2);
                    var num628 = 100;
                    int num629 = ProjectileID.DeathLaser;
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 33);
                    var num630 = (float)Math.Atan2(vector71.Y - (Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f), vector71.X - (Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f));
                    for (var num631 = 0f; num631 <= 4f; num631 += 0.4f)
                    {
                        var num632 = Projectile.NewProjectile(vector71.X, vector71.Y, (float)(Math.Cos(num630 + num631) * num627 * -1.0), (float)(Math.Sin(num630 + num631) * num627 * -1.0), num629, num628, 0f, 0, 0f, 0f);
                        Main.projectile[num632].timeLeft = 600;
                        Main.projectile[num632].tileCollide = false;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num632, 0f, 0f, 0f, 0);
                        }
                        num632 = Projectile.NewProjectile(vector71.X, vector71.Y, (float)(Math.Cos(num630 - num631) * num627 * -1.0), (float)(Math.Sin(num630 - num631) * num627 * -1.0), num629, num628, 0f, 0, 0f, 0f);
                        Main.projectile[num632].timeLeft = 600;
                        Main.projectile[num632].tileCollide = false;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num632, 0f, 0f, 0f, 0);
                        }
                    }
                    npc.localAI[0] = 0f;
                    return;
                }
                return;
            }
            else
            {
                if (npc.ai[2] != 1f)
                {
                    return;
                }
                npc.ai[3] += 1f;
                if (npc.ai[3] >= 200f)
                {
                    npc.localAI[0] = 0f;
                    npc.ai[2] = 0f;
                    npc.ai[3] = 0f;
                    npc.netUpdate = true;
                }
                var vector72 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                var num633 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - 350f - vector72.X;
                var num634 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - 20f - vector72.Y;
                var num635 = (float)Math.Sqrt(num633 * num633 + num634 * num634);
                num635 = 7f / num635;
                num633 *= num635;
                num634 *= num635;
                if (npc.velocity.X > num633)
                {
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.9f;
                    }
                    npc.velocity.X = npc.velocity.X - 0.1f;
                }
                if (npc.velocity.X < num633)
                {
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.9f;
                    }
                    npc.velocity.X = npc.velocity.X + 0.1f;
                }
                if (npc.velocity.Y > num634)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.9f;
                    }
                    npc.velocity.Y = npc.velocity.Y - 0.03f;
                }
                if (npc.velocity.Y < num634)
                {
                    if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.9f;
                    }
                    npc.velocity.Y = npc.velocity.Y + 0.03f;
                }
                npc.localAI[0] += 1f;
                if (npc.localAI[0] >= 100f)
                {
                    var num639 = 12f;
                    var vector73 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height / 2);
                    var num640 = 50;
                    int num641 = ProjectileID.DeathLaser;
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 33);
                    var num642 = (float)Math.Atan2(vector73.Y - (Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f), vector73.X - (Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f));
                    for (var num643 = 0f; num643 <= 4f; num643 += 0.4f)
                    {
                        var num644 = Projectile.NewProjectile(vector73.X, vector73.Y, (float)(Math.Cos(num642 + num643) * num639 * -1.0), (float)(Math.Sin(num642 + num643) * num639 * -1.0), num641, num640, 0f, 0, 0f, 0f);
                        Main.projectile[num644].timeLeft = 600;
                        Main.projectile[num644].tileCollide = false;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num644, 0f, 0f, 0f, 0);
                        }
                        num644 = Projectile.NewProjectile(vector73.X, vector73.Y, (float)(Math.Cos(num642 - num643) * num639 * -1.0), (float)(Math.Sin(num642 - num643) * num639 * -1.0), num641, num640, 0f, 0, 0f, 0f);
                        Main.projectile[num644].timeLeft = 600;
                        Main.projectile[num644].tileCollide = false;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num644, 0f, 0f, 0f, 0);
                        }
                    }
                    npc.localAI[0] = 0f;
                    return;
                }
                return;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            var vector10 = new Vector2(npc.position.X + npc.width * 0.5f - 5f * npc.ai[0], npc.position.Y + 20f);
            for (var m = 0; m < 2; m++)
            {
                var num36 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector10.X;
                var num37 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector10.Y;
                float num38;
                if (m == 0)
                {
                    num36 -= 200f * npc.ai[0];
                    num37 += 130f;
                    num38 = (float)Math.Sqrt(num36 * num36 + num37 * num37);
                    num38 = 92f / num38;
                    vector10.X += num36 * num38;
                    vector10.Y += num37 * num38;
                }
                else
                {
                    num36 -= 50f * npc.ai[0];
                    num37 += 80f;
                    num38 = (float)Math.Sqrt(num36 * num36 + num37 * num37);
                    num38 = 60f / num38;
                    vector10.X += num36 * num38;
                    vector10.Y += num37 * num38;
                }
                var rotation10 = (float)Math.Atan2(num37, num36) - 1.57f;
                var color10 = Lighting.GetColor((int)vector10.X / 16, (int)(vector10.Y / 16f));
                Main.spriteBatch.Draw(Main.boneArm2Texture, new Vector2(vector10.X - Main.screenPosition.X, vector10.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color10, rotation10, new Vector2(Main.boneArmTexture.Width * 0.5f, Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                if (m == 0)
                {
                    vector10.X += num36 * num38 / 2f;
                    vector10.Y += num37 * num38 / 2f;
                }
                else
                {
                    vector10.X += num36 * num38 - 16f;
                    vector10.Y += num37 * num38 - 6f;
                    var num39 = Dust.NewDust(new Vector2(vector10.X, vector10.Y), 30, 10, DustID.Fire, num36 * 0.02f, num37 * 0.02f, 0, default(Color), 2.5f);
                    Main.dust[num39].noGravity = true;
                }
            }
            return true;
        }
    }
}