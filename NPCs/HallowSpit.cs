using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class HallowSpit : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Spit");
            Main.npcFrameCount[npc.type] = 1;
        }
        public override void SetDefaults()
        {
            npc.npcSlots = 1;
            npc.width = 16;
            npc.height = 16;
            npc.aiStyle = -1;
            npc.timeLeft = 750;
            npc.damage = 65;
            npc.DeathSound = SoundID.NPCDeath9;
            npc.lifeMax = 1;
            npc.alpha = 80;
            npc.scale = 0.9f;
            npc.netAlways = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[BuffID.Confused] = true;
        }
        public override void AI()
        {
            if (npc.target == 255)
            {
                npc.TargetClosest(true);
                float num157 = 6f;
                num157 = 7f;
                Vector2 vector15 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float num158 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector15.X;
                float num159 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector15.Y;
                float num160 = (float)Math.Sqrt((double)(num158 * num158 + num159 * num159));
                num160 = num157 / num160;
                npc.velocity.X = num158 * num160;
                npc.velocity.Y = num159 * num160;
            }

            npc.ai[0] += 1f;
            if (npc.ai[0] > 3f)
            {
                npc.ai[0] = 3f;
            }
            if (npc.ai[0] == 2f)
            {
                npc.position += npc.velocity;
                Main.PlaySound(SoundID.NPCKilled, (int)npc.position.X, (int)npc.position.Y, 9);
                for (int num161 = 0; num161 < 20; num161++)
                {
                    int num162 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, DustID.Enchanted_Pink, 0f, 0f, 100, default(Color), 1.8f);
                    Main.dust[num162].velocity *= 1.3f;
                    Main.dust[num162].velocity += npc.velocity;
                    Main.dust[num162].noGravity = true;
                }
            }
            if (Collision.SolidCollision(npc.position, npc.width, npc.height))
            {
                #region spread hallow code
                /*if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					int num163 = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
					int num164 = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
					int num165 = 8;
					for (int num166 = num163 - num165; num166 <= num163 + num165; num166++)
					{
						for (int num167 = num164 - num165; num167 < num164 + num165; num167++)
						{
							if ((double)(Math.Abs(num166 - num163) + Math.Abs(num167 - num164)) < (double)num165 * 0.5)
							{
								if (Main.tile[num166, num167].type == 2)
								{
									Main.tile[num166, num167].type = 109;
									WorldGen.SquareTileFrame(num166, num167, true);
									if (Main.netMode == NetmodeID.Server)
									{
										NetMessage.SendTileSquare(-1, num166, num167, 1);
									}
								}
								else
								{
									if (Main.tile[num166, num167].type == 1)
									{
										Main.tile[num166, num167].type = 117;
										WorldGen.SquareTileFrame(num166, num167, true);
										if (Main.netMode == NetmodeID.Server)
										{
											NetMessage.SendTileSquare(-1, num166, num167, 1);
										}
									}
									else
									{
										if (Main.tile[num166, num167].type == 53)
										{
											Main.tile[num166, num167].type = 116;
											WorldGen.SquareTileFrame(num166, num167, true);
											if (Main.netMode == NetmodeID.Server)
											{
												NetMessage.SendTileSquare(-1, num166, num167, 1);
											}
										}
										else
										{
											if (Main.tile[num166, num167].type == 23)
											{
												Main.tile[num166, num167].type = 109;
												WorldGen.SquareTileFrame(num166, num167, true);
												if (Main.netMode == NetmodeID.Server)
												{
													NetMessage.SendTileSquare(-1, num166, num167, 1);
												}
											}
											else
											{
												if (Main.tile[num166, num167].type == 25)
												{
													Main.tile[num166, num167].type = 117;
													WorldGen.SquareTileFrame(num166, num167, true);
													if (Main.netMode == NetmodeID.Server)
													{
														NetMessage.SendTileSquare(-1, num166, num167, 1);
													}
												}
												else
												{
													if (Main.tile[num166, num167].type == 112)
													{
														Main.tile[num166, num167].type = 116;
														WorldGen.SquareTileFrame(num166, num167, true);
														if (Main.netMode == NetmodeID.Server)
														{
															NetMessage.SendTileSquare(-1, num166, num167, 1);
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}*/
                #endregion
                npc.StrikeNPC(999, 0f, 0, false, false);
            }
            if (npc.timeLeft > 100)
            {
                npc.timeLeft = 100;
            }
            for (int num168 = 0; num168 < 2; num168++)
            {
                int num171 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, DustID.Enchanted_Pink, npc.velocity.X * 0.1f, npc.velocity.Y * 0.1f, 80, default(Color), 1.3f);
                Main.dust[num171].velocity *= 0.3f;
                Main.dust[num171].noGravity = true;
            }
            npc.rotation += 0.4f * (float)npc.direction;
            return;
        }
    }
}