using System;
using ExxoAvalonOrigins.Items.Consumables;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Trophy;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    [AutoloadBossHead]
    public class WallofSteel : ModNPC
    {
        private static Texture2D wosTexture;
        private static Texture2D mechaHungryChainTexture;

        public static void Load()
        {
            wosTexture = ExxoAvalonOrigins.mod.GetTexture("Sprites/WallofSteel");
            mechaHungryChainTexture = ExxoAvalonOrigins.mod.GetTexture("Sprites/MechaHungryChain");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wall of Steel");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.width = 200;
            npc.height = 580;
            npc.boss = npc.noTileCollide = npc.noGravity = npc.behindTiles = true;
            npc.npcSlots = 100f;
            npc.damage = 135;
            npc.lifeMax = 75000;
            npc.timeLeft = 750000;
            npc.defense = 55;
            npc.aiStyle = -1;
            npc.value = Item.buyPrice(0, 10);
            npc.knockBackResist = 0;
            npc.scale = 1.4f;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Confused] = npc.buffImmune[ModContent.BuffType<Buffs.Frozen>()] = npc.buffImmune[BuffID.Poisoned] =
            npc.buffImmune[BuffID.OnFire] = npc.buffImmune[BuffID.CursedInferno] = npc.buffImmune[BuffID.Venom] =
            npc.buffImmune[BuffID.Ichor] = npc.buffImmune[BuffID.Frostburn] = true;
            bossBag = ModContent.ItemType<Items.BossBags.WallofSteelBossBag>();
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 255);
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.85f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.65f);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if (ExxoAvalonOriginsWorld.wos >= 0)
            {
                for (int i = 0; i < 255; i++)
                {
                    if (Main.player[i].gross && Main.player[i].active && Main.player[i].tongued && !Main.player[i].dead)
                    {
                        float num = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + Main.npc[ExxoAvalonOriginsWorld.wos].width / 2;
                        float num2 = Main.npc[ExxoAvalonOriginsWorld.wos].position.Y + Main.npc[ExxoAvalonOriginsWorld.wos].height / 2;
                        var vector = new Vector2(Main.player[i].position.X + Main.player[i].width * 0.5f, Main.player[i].position.Y + Main.player[i].height * 0.5f);
                        float num3 = num - vector.X;
                        float num4 = num2 - vector.Y;
                        float rotation = (float)Math.Atan2(num4, num3) - 1.57f;
                        bool flag = true;
                        while (flag)
                        {
                            float num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
                            if (num5 < 40f)
                            {
                                flag = false;
                            }
                            else
                            {
                                num5 = Main.chain38Texture.Height / num5;
                                num3 *= num5;
                                num4 *= num5;
                                vector.X += num3;
                                vector.Y += num4;
                                num3 = num - vector.X;
                                num4 = num2 - vector.Y;
                                Color color = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16f));
                                spriteBatch.Draw(Main.chain8Texture, new Vector2(vector.X - Main.screenPosition.X, vector.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain8Texture.Width, Main.chain8Texture.Height)), color, rotation, new Vector2(Main.chain8Texture.Width * 0.5f, Main.chain8Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                            }
                        }
                    }
                }
                for (int j = 0; j < 200; j++)
                {
                    if (Main.npc[j].active && (Main.npc[j].type == ModContent.NPCType<NPCs.MechanicalHungry>() || Main.npc[j].type == ModContent.NPCType<NPCs.MechanicalHungry2>()))
                    {
                        float num6 = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + Main.npc[ExxoAvalonOriginsWorld.wos].width / 2;
                        float num7 = Main.npc[ExxoAvalonOriginsWorld.wos].position.Y;
                        float num8 = ExxoAvalonOriginsWorld.wosB - ExxoAvalonOriginsWorld.wosT;
                        bool flag2 = false;
                        if (Main.npc[j].frameCounter > 7.0)
                        {
                            flag2 = true;
                        }
                        num7 = ExxoAvalonOriginsWorld.wosT + num8 * Main.npc[j].ai[0];
                        var vector2 = new Vector2(Main.npc[j].position.X + Main.npc[j].width / 2, Main.npc[j].position.Y + Main.npc[j].height / 2);
                        float num9 = num6 - vector2.X;
                        float num10 = num7 - vector2.Y;
                        float rotation2 = (float)Math.Atan2(num10, num9) - 1.57f;
                        bool flag3 = true;
                        while (flag3)
                        {
                            SpriteEffects effects = SpriteEffects.None;
                            if (flag2)
                            {
                                effects = SpriteEffects.FlipHorizontally;
                                flag2 = false;
                            }
                            else
                            {
                                flag2 = true;
                            }
                            int height = 28;
                            float num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
                            if (num11 < 40f)
                            {
                                height = (int)num11 - 40 + 28;
                                flag3 = false;
                            }
                            num11 = 28f / num11;
                            num9 *= num11;
                            num10 *= num11;
                            vector2.X += num9;
                            vector2.Y += num10;
                            num9 = num6 - vector2.X;
                            num10 = num7 - vector2.Y;
                            Color color2 = Lighting.GetColor((int)vector2.X / 16, (int)(vector2.Y / 16f));
                            Main.spriteBatch.Draw(mechaHungryChainTexture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, mechaHungryChainTexture.Width, height)), color2, rotation2, new Vector2(mechaHungryChainTexture.Width * 0.5f, mechaHungryChainTexture.Height * 0.5f), 1f, effects, 0f);
                        }
                    }
                }
                int heightOfPartToTile = 120;
                float num13 = ExxoAvalonOriginsWorld.wosT;
                float screenYPos = ExxoAvalonOriginsWorld.wosB;
                screenYPos = Main.screenPosition.Y + Main.screenHeight;
                float num15 = (int)((num13 - Main.screenPosition.Y) / heightOfPartToTile) + 1;
                num15 *= heightOfPartToTile;
                if (num15 > 0f)
                {
                    num13 -= num15;
                }
                float num16 = num13;
                float wosPosX = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + 20;
                float num18 = screenYPos - num13;
                bool flag4 = true;
                SpriteEffects effects2 = SpriteEffects.None;
                if (Main.npc[ExxoAvalonOriginsWorld.wos].spriteDirection == -1)
                {
                    wosPosX += 160; // going to the left
                }
                if (Main.npc[ExxoAvalonOriginsWorld.wos].spriteDirection == 1)
                {
                    effects2 = SpriteEffects.FlipHorizontally;
                }
                if (Main.npc[ExxoAvalonOriginsWorld.wos].direction > 0)
                {
                    wosPosX -= 110f; // going to the right
                }
                int num19 = 0;
                if (!Main.gamePaused)
                {
                    ExxoAvalonOriginsWorld.wosF++;
                }
                if (ExxoAvalonOriginsWorld.wosF > 12)
                {
                    num19 = 240;
                    if (ExxoAvalonOriginsWorld.wosF > 17)
                    {
                        ExxoAvalonOriginsWorld.wosF = 0;
                    }
                }
                else if (ExxoAvalonOriginsWorld.wosF > 6)
                {
                    num19 = 120;
                }
                while (flag4)
                {
                    num18 = screenYPos - num16;
                    if (num18 > heightOfPartToTile)
                    {
                        num18 = heightOfPartToTile;
                    }
                    bool flag5 = true;
                    int num20 = 0;
                    while (flag5)
                    {
                        int x = (int)(wosPosX + wosTexture.Width / 2) / 16;
                        int y = (int)(num16 + num20) / 16;
                        Main.spriteBatch.Draw(wosTexture, new Vector2(wosPosX - Main.screenPosition.X, num16 + num20 - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, num19 + num20, wosTexture.Width, 16)), Lighting.GetColor(x, y), 0f, default(Vector2), 1f, effects2, 0f);
                        num20 += 16;
                        if (num20 >= num18)
                        {
                            flag5 = false;
                        }
                    }
                    num16 += heightOfPartToTile;
                    if (num16 >= screenYPos)
                    {
                        flag4 = false;
                    }
                }
            }
            return true;
        }

        public override void AI()
        {
            bool expert = Main.expertMode;
            if (npc.position.X < 160f || npc.position.X > (Main.maxTilesX - 10) * 16)
            {
                npc.active = false;
            }
            if (npc.localAI[0] == 0f)
            {
                npc.localAI[0] = 1f;
                ExxoAvalonOriginsWorld.wosB = -1;
                ExxoAvalonOriginsWorld.wosT = -1;
            }
            npc.localAI[3] += 1f;
            if (npc.localAI[3] >= 600 + Main.rand.Next(1000))
            {
                npc.localAI[3] = -Main.rand.Next(200);
                //Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 10);
            }
            ExxoAvalonOriginsWorld.wos = npc.whoAmI;
            int tilePosX = (int)(npc.position.X / 16f);
            int tilePosXwidth = (int)((npc.position.X + npc.width) / 16f);
            int tilePosYCenter = (int)((npc.position.Y + npc.height / 2) / 16f);
            int num446 = 0;
            int num447 = tilePosYCenter + 7;
            num447 += 4;
            if (ExxoAvalonOriginsWorld.wosB == -1)
            {
                ExxoAvalonOriginsWorld.wosB = num447 * 16;
            }
            else if (ExxoAvalonOriginsWorld.wosB > num447 * 16)
            {
                ExxoAvalonOriginsWorld.wosB--;
                if (ExxoAvalonOriginsWorld.wosB < num447 * 16)
                {
                    ExxoAvalonOriginsWorld.wosB = num447 * 16;
                }
            }
            else if (ExxoAvalonOriginsWorld.wosB < num447 * 16)
            {
                ExxoAvalonOriginsWorld.wosB++;
                if (ExxoAvalonOriginsWorld.wosB > num447 * 16)
                {
                    ExxoAvalonOriginsWorld.wosB = num447 * 16;
                }
            }
            num446 = 0;
            num447 = tilePosYCenter - 7;
            num447 -= 4;
            if (ExxoAvalonOriginsWorld.wosT == -1)
            {
                ExxoAvalonOriginsWorld.wosT = num447 * 16;
            }
            else if (ExxoAvalonOriginsWorld.wosT > num447 * 16)
            {
                ExxoAvalonOriginsWorld.wosT--;
                if (ExxoAvalonOriginsWorld.wosT < num447 * 16)
                {
                    ExxoAvalonOriginsWorld.wosT = num447 * 16;
                }
            }
            else if (ExxoAvalonOriginsWorld.wosT < num447 * 16)
            {
                ExxoAvalonOriginsWorld.wosT++;
                if (ExxoAvalonOriginsWorld.wosT > num447 * 16)
                {
                    ExxoAvalonOriginsWorld.wosT = num447 * 16;
                }
            }
            float num450 = (ExxoAvalonOriginsWorld.wosB + ExxoAvalonOriginsWorld.wosT) / 2 - npc.height / 2;
            if (npc.Center.Y > Main.player[npc.target].Center.Y)
            {
                if (npc.velocity.Y > 0)
                {
                    npc.velocity.Y *= 0.98f;
                }
                npc.velocity.Y -= 0.02f;
                if (npc.velocity.Y < -2.2f)
                {
                    npc.velocity.Y = -2.2f;
                }
            }
            if (npc.Center.Y < Main.player[npc.target].Center.Y)
            {
                if (npc.velocity.Y < 0)
                {
                    npc.velocity.Y *= 0.98f;
                }
                npc.velocity.Y += 0.02f;
                if (npc.velocity.Y > 2.2f)
                {
                    npc.velocity.Y = 2.2f;
                }
            }
            //npc.velocity.Y = 0f;
            //npc.position.Y = num450;
            if (npc.position.Y / 16 < Main.maxTilesY - 200)
            {
                npc.position.Y = (Main.maxTilesY - 200) * 16;
            }

            float num451 = 2.5f;
            if (npc.life < npc.lifeMax * 0.75)
            {
                num451 += 0.25f;
            }
            if (npc.life < npc.lifeMax * 0.5)
            {
                num451 += 0.4f;
            }
            if (npc.life < npc.lifeMax * 0.25)
            {
                num451 += 0.5f;
            }
            if (npc.life < npc.lifeMax * 0.1)
            {
                num451 += 0.6f;
            }
            if (npc.life < npc.lifeMax * 0.66 && Main.expertMode)
            {
                num451 += 0.3f;
            }
            if (npc.life < npc.lifeMax * 0.33 && Main.expertMode)
            {
                num451 += 0.3f;
            }
            if (npc.life < npc.lifeMax * 0.05 && Main.expertMode)
            {
                num451 += 0.6f;
            }
            if (npc.life < npc.lifeMax * 0.035 && Main.expertMode)
            {
                num451 += 0.6f;
            }
            if (npc.life < npc.lifeMax * 0.025 && Main.expertMode)
            {
                num451 += 0.6f;
            }
            if (npc.velocity.X == 0f)
            {
                npc.TargetClosest(true);
                npc.velocity.X = npc.direction;
            }
            if (npc.velocity.X < 0f)
            {
                npc.velocity.X = -num451;
                npc.direction = -1;
            }
            else
            {
                npc.velocity.X = num451;
                npc.direction = 1;
            }
            if (npc.life > npc.lifeMax / 3)
            {
                npc.ai[1]++;
                if (npc.ai[1] == 90)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient) // leeches
                    {
                        int num442 = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)(npc.position.Y + npc.height / 2 + 20f), ModContent.NPCType<MechanicalLeechHead>(), 1);
                        Main.npc[num442].velocity.X = npc.direction * 8;
                    }
                }
                if (npc.ai[1] > 90)
                {
                    int fire;
                    float f = 0f;
                    int dmg = Main.expertMode ? 75 : 60;
                    var laserPos = new Vector2((npc.velocity.X < 0 ? npc.position.X : npc.position.X + npc.width), ExxoAvalonOriginsWorld.wosT);
                    float rotation = (float)Math.Atan2(laserPos.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), laserPos.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, ExxoAvalonOriginsWorld.wosT, 33);
                    while (f <= .1f)
                    {
                        fire = Projectile.NewProjectile(laserPos.X, laserPos.Y, (float)((Math.Cos(rotation + f) * 12f) * -1), (float)((Math.Sin(rotation + f) * 12f) * -1), ProjectileID.CursedFlameHostile, dmg, 6f);
                        Main.projectile[fire].timeLeft = 600;
                        Main.projectile[fire].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, fire);
                        }
                        fire = Projectile.NewProjectile(laserPos.X, laserPos.Y, (float)((Math.Cos(rotation - f) * 12f) * -1), (float)((Math.Sin(rotation - f) * 12f) * -1), ProjectileID.CursedFlameHostile, dmg, 6f);
                        Main.projectile[fire].timeLeft = 600;
                        Main.projectile[fire].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, fire);
                        }
                        f += .034f;
                    }
                    npc.ai[1] = 0;
                }
                npc.ai[2]++;
                if (npc.ai[2] == 100)
                {
                    int laser = Projectile.NewProjectile((npc.velocity.X < 0 ? npc.position.X : npc.position.X + npc.width), ExxoAvalonOriginsWorld.wosB, npc.velocity.X, npc.velocity.Y, ProjectileID.DeathLaser, Main.expertMode ? 70 : 55, 4f);
                    Main.projectile[laser].velocity = Vector2.Normalize(Main.player[npc.target].Center - new Vector2(npc.position.X, ExxoAvalonOriginsWorld.wosB)) * 5f;
                    Main.projectile[laser].hostile = true;
                    Main.projectile[laser].friendly = false;
                    Main.projectile[laser].tileCollide = false;
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, laser);
                    }

                    npc.ai[2] = 0;
                }
                if (npc.ai[2] == 90)
                {
                    int fire;
                    float f = 0f;
                    var laserPos = new Vector2((npc.velocity.X < 0 ? npc.position.X : npc.position.X + npc.width), ExxoAvalonOriginsWorld.wosT);
                    float rotation = (float)Math.Atan2(laserPos.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), laserPos.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, ExxoAvalonOriginsWorld.wosT, 33);
                    //while (f <= .1f)
                    //{
                    fire = Projectile.NewProjectile(laserPos.X, laserPos.Y, (float)((Math.Cos(rotation + f) * 12f) * -1), (float)((Math.Sin(rotation + f) * 12f) * -1), ProjectileID.CursedFlameFriendly, Main.expertMode ? 70 : 55, 6f);
                    Main.projectile[fire].timeLeft = 600;
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, fire);
                    }
                    fire = Projectile.NewProjectile(laserPos.X, laserPos.Y, (float)((Math.Cos(rotation - f) * 12f) * -1), (float)((Math.Sin(rotation - f) * 12f) * -1), ProjectileID.CursedFlameFriendly, Main.expertMode ? 70 : 55, 6f);
                    Main.projectile[fire].timeLeft = 600;
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, fire);
                    }
                    f += .1f;
                    //}
                }
            }
            else
            {
                npc.ai[3]++;
                if (npc.ai[3] == 1)
                {
                    npc.defense = 0;
                    Main.PlaySound(SoundID.Item, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/LaserCharge"));
                }
                if (npc.ai[3] >= 60 && npc.ai[3] < 80)
                {
                    if (npc.ai[3] == 60)
                    {
                        Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.Center.Y, 33);
                        npc.ai[1] = (npc.velocity.X < 0 ? npc.position.X : npc.position.X + npc.width);
                        npc.ai[2] = npc.Center.Y;
                        npc.localAI[1] = npc.velocity.X;
                        npc.localAI[2] = npc.velocity.Y;
                    }
                    int wide = Projectile.NewProjectile(npc.ai[1], npc.ai[2], npc.localAI[1], npc.localAI[2], ModContent.ProjectileType<Projectiles.WallofSteelLaser>(), 100, 4f);
                    if (npc.velocity.X > 0)
                    {
                        Main.projectile[wide].velocity = Vector2.Normalize(new Vector2(npc.ai[1], npc.ai[2]) - new Vector2(npc.ai[1] - 100, npc.ai[2])) * 20f;
                    }
                    else if (npc.velocity.X < 0)
                    {
                        Main.projectile[wide].velocity = Vector2.Normalize(new Vector2(npc.ai[1] - 100, npc.ai[2]) - new Vector2(npc.ai[1], npc.ai[2])) * 20f;
                    }

                    Main.projectile[wide].tileCollide = false;
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, wide);
                    }
                }
                if (npc.ai[3] > 100 && npc.ai[3] < 150)
                {
                    npc.defense = 55;
                    int fire = Projectile.NewProjectile((npc.velocity.X < 0 ? npc.position.X : npc.position.X + npc.width), ExxoAvalonOriginsWorld.wosT, npc.velocity.X, npc.velocity.Y, ProjectileID.EyeFire, 45, 4f);
                    Main.projectile[fire].velocity = Vector2.Normalize(Main.player[npc.target].Center - new Vector2(npc.position.X, ExxoAvalonOriginsWorld.wosT)) * 20f;
                    Main.projectile[fire].tileCollide = false;
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, fire);
                    }
                }
                if (npc.ai[3] > 300)
                {
                    npc.ai[3] = 0;
                }
            }
            npc.spriteDirection = npc.direction;
            if (npc.localAI[0] == 1f && Main.netMode != NetmodeID.MultiplayerClient)
            {
                npc.localAI[0] = 2f;
                for (int num456 = 0; num456 < 11; num456++)
                {
                    int hungry = NPC.NewNPC((int)npc.position.X, (int)num450, ModContent.NPCType<NPCs.MechanicalHungry>(), npc.whoAmI);
                    Main.npc[hungry].ai[0] = num456 * 0.1f - 0.05f;
                }
                return;
            }
        }

        public override void NPCLoot()
        {
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore1"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore2"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore3"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore3"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore4"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore5"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore6"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore6"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore7"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore8"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore9"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore10"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore11"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore12"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore13"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/WallofSteelGore14"), npc.scale);
            ExxoAvalonOriginsWorld.wos = -1;
            if (!ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.hardMode)
            {
                //int numplayers = 0;
                //for (int i = 0; i < 255; i++)
                //{
                //    if (Main.player[i].active) numplayers++;
                //}
                //npc.DropItemInstanced(npc.position, new Vector2(npc.width, npc.height), ModContent.ItemType<DarkStarHeart>());
                ModContent.GetInstance<ExxoAvalonOriginsWorld>().InitiateSuperHardmode();
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<WallofSteelTrophy>(), 1, false, 0, false);
            }

            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                int drop = Main.rand.Next(5);
                if (drop == 0)
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<FleshBoiler>(), 1, false, -1, false);
                }
                if (drop == 1)
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<MagicCleaver>(), 1, false, -1, false);
                }
                if (drop == 2)
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Accessories.BubbleBoost>(), 1, false, -1, false);
                }
                Item.NewItem(npc.getRect(), ModContent.ItemType<SoulofBlight>(), Main.rand.Next(40, 56), false, 0, false);
                Item.NewItem(npc.getRect(), ModContent.ItemType<HellsteelPlate>(), Main.rand.Next(20, 31), false, 0, false);
            }
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                int num22 = (int)(npc.position.X + (npc.width / 2)) / 16;
                int num23 = (int)(npc.position.Y + (npc.height / 2)) / 16;
                int num24 = npc.width / 4 / 16 + 1;
                for (int k = num22 - num24; k <= num22 + num24; k++)
                {
                    for (int l = num23 - num24; l <= num23 + num24; l++)
                    {
                        if ((k == num22 - num24 || k == num22 + num24 || l == num23 - num24 || l == num23 + num24) && !Main.tile[k, l].active())
                        {
                            Main.tile[k, l].type = (ushort)ModContent.TileType<Tiles.OblivionBrick>();
                            Main.tile[k, l].active(true);
                        }
                        Main.tile[k, l].lava(false);
                        Main.tile[k, l].liquid = 0;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else
                        {
                            WorldGen.SquareTileFrame(k, l, true);
                        }
                    }
                }
            }
        }
    }
}
