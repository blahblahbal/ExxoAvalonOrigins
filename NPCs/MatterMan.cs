using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;

namespace ExxoAvalonOrigins.NPCs
{
    public class MatterMan : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Matter Man");
            Main.npcFrameCount[npc.type] = 5;
        }

        public override void SetDefaults()
        {
            npc.damage = 100;
            npc.netAlways = true;
            npc.scale = 1f;
            npc.lifeMax = 1200;
            npc.defense = 40;
            npc.width = 18;
            npc.aiStyle = -1;
            npc.value = Item.buyPrice(0, 1, 0, 0);
            npc.height = 40;
            npc.knockBackResist = 0.3f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.MatterManBanner>();
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.65f);
            npc.damage = (int)(npc.damage * 0.6f);
        }

        public override void NPCLoot()
        {
        }

        public override void AI()
        {
            bool flag3 = false;
            if (npc.velocity.X == 0f)
            {
                flag3 = true;
            }
            if (npc.justHit)
            {
                flag3 = false;
            }
            int num22 = 60;
            bool flag4 = false;
            bool flag5 = true;
            if ((npc.type != 387 && npc.type != 110 && npc.type != 111 && npc.type != 206 && npc.type != 216 && npc.type != 214 && npc.type != 215 && npc.type != 291 && npc.type != 292 && npc.type != 293 && npc.type != 350) || npc.ai[2] <= 0f)
            {
                if (npc.velocity.Y == 0f && ((npc.velocity.X > 0f && npc.direction < 0) || (npc.velocity.X < 0f && npc.direction > 0)))
                {
                    flag4 = true;
                }
                if (npc.position.X == npc.oldPosition.X || npc.ai[3] >= (float)num22 || flag4)
                {
                    npc.ai[3] += 1f;
                }
                else if ((double)Math.Abs(npc.velocity.X) > 0.9 && npc.ai[3] > 0f)
                {
                    npc.ai[3] -= 1f;
                }
                if (npc.ai[3] > (float)(num22 * 10))
                {
                    npc.ai[3] = 0f;
                }
                if (npc.justHit)
                {
                    npc.ai[3] = 0f;
                }
                if (npc.ai[3] == (float)num22)
                {
                    npc.netUpdate = true;
                }
            }
            if ((Main.eclipse || !Main.dayTime || (double)npc.position.Y > Main.worldSurface * 16.0 || npc.type == 343 || npc.type == 26 || npc.type == 27 || npc.type == 28 || npc.type == 31 || npc.type == 294 || npc.type == 295 || npc.type == 296 || npc.type == 47 || npc.type == 67 || npc.type == 73 || npc.type == 77 || npc.type == 78 || npc.type == 79 || npc.type == 80 || npc.type == 110 || npc.type == 111 || npc.type == 120 || npc.type == 168 || npc.type == 181 || npc.type == 185 || npc.type == 198 || npc.type == 199 || npc.type == 198 || npc.type == 206 || npc.type == 217 || npc.type == 218 || npc.type == 219 || npc.type == 220 || npc.type == 239 || npc.type == 243 || npc.type == 254 || (npc.type == 255 | npc.type == 257) || npc.type == 258 || npc.type == 291 || npc.type == 292 || npc.type == 293 || (npc.type >= 212 && npc.type <= 216) || npc.type == 350 || npc.type == 471 || npc.type == 482 || npc.type == 485 || npc.type == 486) && npc.ai[3] < (float)num22)
            {
                if ((npc.type == 3 || npc.type == 331 || npc.type == 332 || npc.type == 21 || npc.type == 31 || npc.type == 482 || npc.type == 294 || npc.type == 295 || npc.type == 296 || npc.type == 77 || npc.type == 110 || npc.type == 132 || npc.type == 167 || npc.type == 161 || npc.type == 162 || npc.type == 186 || npc.type == 187 || npc.type == 188 || npc.type == 189 || npc.type == 197 || npc.type == 200 || npc.type == 201 || npc.type == 202 || npc.type == 203 || npc.type == 223 || npc.type == 291 || npc.type == 292 || npc.type == 293 || npc.type == 320 || npc.type == 321 || npc.type == 319) && Main.rand.Next(1000) == 0)
                {
                    Main.PlaySound(14, (int)npc.position.X, (int)npc.position.Y, 1);
                }
                if ((npc.type == 78 || npc.type == 79 || npc.type == 80) && Main.rand.Next(500) == 0)
                {
                    Main.PlaySound(26, (int)npc.position.X, (int)npc.position.Y, 1);
                }
                if (npc.type == 159 && Main.rand.Next(500) == 0)
                {
                    Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 7);
                }
                if (npc.type == 162 && Main.rand.Next(500) == 0)
                {
                    Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 6);
                }
                if (npc.type == 181 && Main.rand.Next(500) == 0)
                {
                    Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 8);
                }
                if (npc.type >= 269 && npc.type <= 280 && Main.rand.Next(1000) == 0)
                {
                    Main.PlaySound(14, (int)npc.position.X, (int)npc.position.Y, 1);
                }
                npc.TargetClosest(true);
            }
            else if ((npc.type != 110 && npc.type != 111 && npc.type != 206 && npc.type != 216 && npc.type != 214 && npc.type != 215 && npc.type != 291 && npc.type != 292 && npc.type != 293 && npc.type != 350) || npc.ai[2] <= 0f)
            {
                if (Main.dayTime && (double)(npc.position.Y / 16f) < Main.worldSurface && npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                }
                if (npc.velocity.X == 0f)
                {
                    if (npc.velocity.Y == 0f)
                    {
                        npc.ai[0] += 1f;
                        if (npc.ai[0] >= 2f)
                        {
                            npc.direction *= -1;
                            npc.spriteDirection = npc.direction;
                            npc.ai[0] = 0f;
                        }
                    }
                }
                else
                {
                    npc.ai[0] = 0f;
                }
                if (npc.direction == 0)
                {
                    npc.direction = 1;
                }
            }
            else if (npc.type == ModContent.NPCType<MatterMan>())
            {
                float num29 = 3f;
                num29 *= 1f + (1f - npc.scale);
                if (npc.velocity.X < -num29 || npc.velocity.X > num29)
                {
                    if (npc.velocity.Y == 0f)
                    {
                        npc.velocity *= 0.8f;
                    }
                }
                else if (npc.velocity.X < num29 && npc.direction == 1)
                {
                    npc.velocity.X = npc.velocity.X + 0.07f;
                    if (npc.velocity.X > num29)
                    {
                        npc.velocity.X = num29;
                    }
                }
                else if (npc.velocity.X > -num29 && npc.direction == -1)
                {
                    npc.velocity.X = npc.velocity.X - 0.07f;
                    if (npc.velocity.X < -num29)
                    {
                        npc.velocity.X = -num29;
                    }
                }
            }
            else if (npc.type != 110 && npc.type != 111 && npc.type != 206 && npc.type != 214 && npc.type != 215 && npc.type != 216 && npc.type != 290 && npc.type != 291 && npc.type != 292 && npc.type != 293 && npc.type != 350 && npc.type != 387)
            {
                float num39 = 1f;
                if (npc.type == 186)
                {
                    num39 = 1.1f;
                }
                if (npc.type == 187)
                {
                    num39 = 0.9f;
                }
                if (npc.type == 188)
                {
                    num39 = 1.2f;
                }
                if (npc.type == 189)
                {
                    num39 = 0.8f;
                }
                if (npc.type == 132)
                {
                    num39 = 0.95f;
                }
                if (npc.type == 200)
                {
                    num39 = 0.87f;
                }
                if (npc.type == 223)
                {
                    num39 = 1.05f;
                }
                if (npc.type == 3 || npc.type == 132 || npc.type == 186 || npc.type == 187 || npc.type == 188 || npc.type == 189 || npc.type == 200 || npc.type == 223 || npc.type == 331 || npc.type == 332)
                {
                    num39 *= 1f + (1f - npc.scale);
                }
                if (npc.velocity.X < -num39 || npc.velocity.X > num39)
                {
                    if (npc.velocity.Y == 0f)
                    {
                        npc.velocity *= 0.8f;
                    }
                }
                else if (npc.velocity.X < num39 && npc.direction == 1)
                {
                    npc.velocity.X = npc.velocity.X + 0.07f;
                    if (npc.velocity.X > num39)
                    {
                        npc.velocity.X = num39;
                    }
                }
                else if (npc.velocity.X > -num39 && npc.direction == -1)
                {
                    npc.velocity.X = npc.velocity.X - 0.07f;
                    if (npc.velocity.X < -num39)
                    {
                        npc.velocity.X = -num39;
                    }
                }
            }
            bool flag11 = false;
            if (npc.velocity.Y == 0f)
            {
                int num93 = (int)(npc.position.Y + (float)npc.height + 7f) / 16;
                int num94 = (int)npc.position.X / 16;
                int num95 = (int)(npc.position.X + (float)npc.width) / 16;
                for (int num96 = num94; num96 <= num95; num96++)
                {
                    if (Main.tile[num96, num93] == null)
                    {
                        return;
                    }
                    if (Main.tile[num96, num93].nactive() && Main.tileSolid[(int)Main.tile[num96, num93].type])
                    {
                        flag11 = true;
                        break;
                    }
                }
            }
            if (npc.velocity.Y >= 0f)
            {
                int num97 = 0;
                if (npc.velocity.X < 0f)
                {
                    num97 = -1;
                }
                if (npc.velocity.X > 0f)
                {
                    num97 = 1;
                }
                Vector2 vector10 = npc.position;
                vector10.X += npc.velocity.X;
                int num98 = (int)((vector10.X + (float)(npc.width / 2) + (float)((npc.width / 2 + 1) * num97)) / 16f);
                int num99 = (int)((vector10.Y + (float)npc.height - 1f) / 16f);
                if (Main.tile[num98, num99] == null)
                {
                    Main.tile[num98, num99] = new Tile();
                }
                if (Main.tile[num98, num99 - 1] == null)
                {
                    Main.tile[num98, num99 - 1] = new Tile();
                }
                if (Main.tile[num98, num99 - 2] == null)
                {
                    Main.tile[num98, num99 - 2] = new Tile();
                }
                if (Main.tile[num98, num99 - 3] == null)
                {
                    Main.tile[num98, num99 - 3] = new Tile();
                }
                if (Main.tile[num98, num99 + 1] == null)
                {
                    Main.tile[num98, num99 + 1] = new Tile();
                }
                if (Main.tile[num98 - num97, num99 - 3] == null)
                {
                    Main.tile[num98 - num97, num99 - 3] = new Tile();
                }
                if ((float)(num98 * 16) < vector10.X + (float)npc.width && (float)(num98 * 16 + 16) > vector10.X && ((Main.tile[num98, num99].nactive() && !Main.tile[num98, num99].topSlope() && !Main.tile[num98, num99 - 1].topSlope() && Main.tileSolid[(int)Main.tile[num98, num99].type] && !Main.tileSolidTop[(int)Main.tile[num98, num99].type]) || (Main.tile[num98, num99 - 1].halfBrick() && Main.tile[num98, num99 - 1].nactive())) && (!Main.tile[num98, num99 - 1].nactive() || !Main.tileSolid[(int)Main.tile[num98, num99 - 1].type] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 1].type] || (Main.tile[num98, num99 - 1].halfBrick() && (!Main.tile[num98, num99 - 4].nactive() || !Main.tileSolid[(int)Main.tile[num98, num99 - 4].type] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 4].type]))) && (!Main.tile[num98, num99 - 2].nactive() || !Main.tileSolid[(int)Main.tile[num98, num99 - 2].type] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 2].type]) && (!Main.tile[num98, num99 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num98, num99 - 3].type] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 3].type]) && (!Main.tile[num98 - num97, num99 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num98 - num97, num99 - 3].type]))
                {
                    float num100 = (float)(num99 * 16);
                    if (Main.tile[num98, num99].halfBrick())
                    {
                        num100 += 8f;
                    }
                    if (Main.tile[num98, num99 - 1].halfBrick())
                    {
                        num100 -= 8f;
                    }
                    if (num100 < vector10.Y + (float)npc.height)
                    {
                        float num101 = vector10.Y + (float)npc.height - num100;
                        float num102 = 16.1f;
                        if (npc.type == 163 || npc.type == 164 || npc.type == 236 || npc.type == 239)
                        {
                            num102 += 8f;
                        }
                        if (num101 <= num102)
                        {
                            npc.gfxOffY += npc.position.Y + (float)npc.height - num100;
                            npc.position.Y = num100 - (float)npc.height;
                            if (num101 < 9f)
                            {
                                npc.stepSpeed = 1f;
                            }
                            else
                            {
                                npc.stepSpeed = 2f;
                            }
                        }
                    }
                }
            }
            if (flag11)
            {
                int num103 = (int)((npc.position.X + (float)(npc.width / 2) + (float)(15 * npc.direction)) / 16f);
                int num104 = (int)((npc.position.Y + (float)npc.height - 15f) / 16f);
                if (npc.type == 109 || npc.type == 163 || npc.type == 164 || npc.type == 199 || npc.type == 236 || npc.type == 239 || npc.type == 257 || npc.type == 258 || npc.type == 290)
                {
                    num103 = (int)((npc.position.X + (float)(npc.width / 2) + (float)((npc.width / 2 + 16) * npc.direction)) / 16f);
                }
                if (Main.tile[num103, num104] == null)
                {
                    Main.tile[num103, num104] = new Tile();
                }
                if (Main.tile[num103, num104 - 1] == null)
                {
                    Main.tile[num103, num104 - 1] = new Tile();
                }
                if (Main.tile[num103, num104 - 2] == null)
                {
                    Main.tile[num103, num104 - 2] = new Tile();
                }
                if (Main.tile[num103, num104 - 3] == null)
                {
                    Main.tile[num103, num104 - 3] = new Tile();
                }
                if (Main.tile[num103, num104 + 1] == null)
                {
                    Main.tile[num103, num104 + 1] = new Tile();
                }
                if (Main.tile[num103 + npc.direction, num104 - 1] == null)
                {
                    Main.tile[num103 + npc.direction, num104 - 1] = new Tile();
                }
                if (Main.tile[num103 + npc.direction, num104 + 1] == null)
                {
                    Main.tile[num103 + npc.direction, num104 + 1] = new Tile();
                }
                if (Main.tile[num103 - npc.direction, num104 + 1] == null)
                {
                    Main.tile[num103 - npc.direction, num104 + 1] = new Tile();
                }
                Main.tile[num103, num104 + 1].halfBrick();
                if (Main.tile[num103, num104 - 1].nactive() && (Main.tile[num103, num104 - 1].type == 10 || Main.tile[num103, num104 - 1].type == 485) && flag5)
                {
                    npc.ai[2] += 1f;
                    npc.ai[3] = 0f;
                    if (npc.ai[2] >= 60f)
                    {
                        if (!Main.bloodMoon && (npc.type == 3 || npc.type == 331 || npc.type == 332 || npc.type == 132 || npc.type == 161 || npc.type == 186 || npc.type == 187 || npc.type == 188 || npc.type == 189 || npc.type == 200 || npc.type == 223 || npc.type == 320 || npc.type == 321 || npc.type == 319))
                        {
                            npc.ai[1] = 0f;
                        }
                        npc.velocity.X = 0.5f * (float)(-(float)npc.direction);
                        npc.ai[1] += 5f;
                        if (npc.type == 27)
                        {
                            npc.ai[1] += 1f;
                        }
                        if (npc.type == 31 || npc.type == 294 || npc.type == 295 || npc.type == 296 || npc.type == 482)
                        {
                            npc.ai[1] += 6f;
                        }
                        npc.ai[2] = 0f;
                        bool flag12 = false;
                        if (npc.ai[1] >= 10f)
                        {
                            flag12 = true;
                            npc.ai[1] = 10f;
                        }
                        WorldGen.KillTile(num103, num104 - 1, true, false, false);
                        if ((Main.netMode != 1 || !flag12) && flag12 && Main.netMode != 1)
                        {
                            if (npc.type == 26)
                            {
                                WorldGen.KillTile(num103, num104 - 1, false, false, false);
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendData(17, -1, -1, NetworkText.Empty, 0, (float)num103, (float)(num104 - 1), 0f, 0);
                                }
                            }
                            else
                            {
                                bool flag13 = WorldGen.OpenDoor(num103, num104 - 1, npc.direction);
                                if (!flag13)
                                {
                                    npc.ai[3] = (float)num22;
                                    npc.netUpdate = true;
                                }
                                if (Main.netMode == 2 && flag13)
                                {
                                    NetMessage.SendData(19, -1, -1, NetworkText.Empty, 0, (float)num103, (float)(num104 - 1), (float)npc.direction, 0);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if ((npc.velocity.X < 0f && npc.spriteDirection == -1) || (npc.velocity.X > 0f && npc.spriteDirection == 1))
                    {
                        if (Main.tile[num103, num104 - 2].nactive() && Main.tileSolid[(int)Main.tile[num103, num104 - 2].type])
                        {
                            if (Main.tile[num103, num104 - 3].nactive() && Main.tileSolid[(int)Main.tile[num103, num104 - 3].type])
                            {
                                npc.velocity.Y = -8f;
                                npc.netUpdate = true;
                            }
                            else
                            {
                                npc.velocity.Y = -7f;
                                npc.netUpdate = true;
                            }
                        }
                        else if (Main.tile[num103, num104 - 1].nactive() && Main.tileSolid[(int)Main.tile[num103, num104 - 1].type])
                        {
                            npc.velocity.Y = -6f;
                            npc.netUpdate = true;
                        }
                        else if (npc.position.Y + (float)npc.height - (float)(num104 * 16) > 20f && Main.tile[num103, num104].nactive() && !Main.tile[num103, num104].topSlope() && Main.tileSolid[(int)Main.tile[num103, num104].type])
                        {
                            npc.velocity.Y = -5f;
                            npc.netUpdate = true;
                        }
                        else if (npc.directionY < 0 && npc.type != 67 && (!Main.tile[num103, num104 + 1].nactive() || !Main.tileSolid[(int)Main.tile[num103, num104 + 1].type]) && (!Main.tile[num103 + npc.direction, num104 + 1].nactive() || !Main.tileSolid[(int)Main.tile[num103 + npc.direction, num104 + 1].type]))
                        {
                            npc.velocity.Y = -8f;
                            npc.velocity.X = npc.velocity.X * 1.5f;
                            npc.netUpdate = true;
                        }
                        else if (flag5)
                        {
                            npc.ai[1] = 0f;
                            npc.ai[2] = 0f;
                        }
                        if (npc.velocity.Y == 0f && flag3 && npc.ai[3] == 1f)
                        {
                            npc.velocity.Y = -5f;
                        }
                    }
                }
            }
            else if (flag5)
            {
                npc.ai[1] = 0f;
                npc.ai[2] = 0f;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneDarkMatter && !spawnInfo.player.InPillarZone() && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode)
            {
                return 1f;
            }
            return 0f;
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.X > 0f)
            {
                npc.spriteDirection = 1;
            }
            if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = -1;
            }
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 6.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MatterManHead"), 1f);
            }
        }
    }
}
