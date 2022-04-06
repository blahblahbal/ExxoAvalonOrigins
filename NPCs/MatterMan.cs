using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class MatterMan : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Matter Man");
        Main.npcFrameCount[NPC.type] = 5;
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                BuffID.Confused,
                BuffID.CursedInferno,
                BuffID.OnFire
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }

    public override void SetDefaults()
    {
        NPC.damage = 100;
        NPC.netAlways = true;
        NPC.scale = 1f;
        NPC.lifeMax = 1200;
        NPC.defense = 40;
        NPC.width = 18;
        NPC.aiStyle = -1;
        NPC.value = Item.buyPrice(0, 1, 0, 0);
        NPC.height = 40;
        NPC.knockBackResist = 0.3f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath2;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.MatterManBanner>();
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.65f);
        NPC.damage = (int)(NPC.damage * 0.6f);
    }
    public override void AI()
    {
        bool flag3 = false;
        if (NPC.velocity.X == 0f)
        {
            flag3 = true;
        }
        if (NPC.justHit)
        {
            flag3 = false;
        }
        int num22 = 60;
        bool flag4 = false;
        bool flag5 = true;
        if ((NPC.type != 387 && NPC.type != 110 && NPC.type != 111 && NPC.type != 206 && NPC.type != 216 && NPC.type != 214 && NPC.type != 215 && NPC.type != 291 && NPC.type != 292 && NPC.type != 293 && NPC.type != 350) || NPC.ai[2] <= 0f)
        {
            if (NPC.velocity.Y == 0f && ((NPC.velocity.X > 0f && NPC.direction < 0) || (NPC.velocity.X < 0f && NPC.direction > 0)))
            {
                flag4 = true;
            }
            if (NPC.position.X == NPC.oldPosition.X || NPC.ai[3] >= (float)num22 || flag4)
            {
                NPC.ai[3] += 1f;
            }
            else if ((double)Math.Abs(NPC.velocity.X) > 0.9 && NPC.ai[3] > 0f)
            {
                NPC.ai[3] -= 1f;
            }
            if (NPC.ai[3] > (float)(num22 * 10))
            {
                NPC.ai[3] = 0f;
            }
            if (NPC.justHit)
            {
                NPC.ai[3] = 0f;
            }
            if (NPC.ai[3] == (float)num22)
            {
                NPC.netUpdate = true;
            }
        }
        if ((Main.eclipse || !Main.dayTime || (double)NPC.position.Y > Main.worldSurface * 16.0 || NPC.type == 343 || NPC.type == 26 || NPC.type == 27 || NPC.type == 28 || NPC.type == 31 || NPC.type == 294 || NPC.type == 295 || NPC.type == 296 || NPC.type == 47 || NPC.type == 67 || NPC.type == 73 || NPC.type == 77 || NPC.type == 78 || NPC.type == 79 || NPC.type == 80 || NPC.type == 110 || NPC.type == 111 || NPC.type == 120 || NPC.type == 168 || NPC.type == 181 || NPC.type == 185 || NPC.type == 198 || NPC.type == 199 || NPC.type == 198 || NPC.type == 206 || NPC.type == 217 || NPC.type == 218 || NPC.type == 219 || NPC.type == 220 || NPC.type == 239 || NPC.type == 243 || NPC.type == 254 || (NPC.type == 255 | NPC.type == 257) || NPC.type == 258 || NPC.type == 291 || NPC.type == 292 || NPC.type == 293 || (NPC.type >= 212 && NPC.type <= 216) || NPC.type == 350 || NPC.type == 471 || NPC.type == 482 || NPC.type == 485 || NPC.type == 486) && NPC.ai[3] < (float)num22)
        {
            if ((NPC.type == 3 || NPC.type == 331 || NPC.type == 332 || NPC.type == 21 || NPC.type == 31 || NPC.type == 482 || NPC.type == 294 || NPC.type == 295 || NPC.type == 296 || NPC.type == 77 || NPC.type == 110 || NPC.type == 132 || NPC.type == 167 || NPC.type == 161 || NPC.type == 162 || NPC.type == 186 || NPC.type == 187 || NPC.type == 188 || NPC.type == 189 || NPC.type == 197 || NPC.type == 200 || NPC.type == 201 || NPC.type == 202 || NPC.type == 203 || NPC.type == 223 || NPC.type == 291 || NPC.type == 292 || NPC.type == 293 || NPC.type == 320 || NPC.type == 321 || NPC.type == 319) && Main.rand.Next(1000) == 0)
            {
                SoundEngine.PlaySound(14, (int)NPC.position.X, (int)NPC.position.Y, 1);
            }
            if ((NPC.type == 78 || NPC.type == 79 || NPC.type == 80) && Main.rand.Next(500) == 0)
            {
                SoundEngine.PlaySound(26, (int)NPC.position.X, (int)NPC.position.Y, 1);
            }
            if (NPC.type == 159 && Main.rand.Next(500) == 0)
            {
                SoundEngine.PlaySound(29, (int)NPC.position.X, (int)NPC.position.Y, 7);
            }
            if (NPC.type == 162 && Main.rand.Next(500) == 0)
            {
                SoundEngine.PlaySound(29, (int)NPC.position.X, (int)NPC.position.Y, 6);
            }
            if (NPC.type == 181 && Main.rand.Next(500) == 0)
            {
                SoundEngine.PlaySound(29, (int)NPC.position.X, (int)NPC.position.Y, 8);
            }
            if (NPC.type >= 269 && NPC.type <= 280 && Main.rand.Next(1000) == 0)
            {
                SoundEngine.PlaySound(14, (int)NPC.position.X, (int)NPC.position.Y, 1);
            }
            NPC.TargetClosest(true);
        }
        else if ((NPC.type != 110 && NPC.type != 111 && NPC.type != 206 && NPC.type != 216 && NPC.type != 214 && NPC.type != 215 && NPC.type != 291 && NPC.type != 292 && NPC.type != 293 && NPC.type != 350) || NPC.ai[2] <= 0f)
        {
            if (Main.dayTime && (double)(NPC.position.Y / 16f) < Main.worldSurface && NPC.timeLeft > 10)
            {
                NPC.timeLeft = 10;
            }
            if (NPC.velocity.X == 0f)
            {
                if (NPC.velocity.Y == 0f)
                {
                    NPC.ai[0] += 1f;
                    if (NPC.ai[0] >= 2f)
                    {
                        NPC.direction *= -1;
                        NPC.spriteDirection = NPC.direction;
                        NPC.ai[0] = 0f;
                    }
                }
            }
            else
            {
                NPC.ai[0] = 0f;
            }
            if (NPC.direction == 0)
            {
                NPC.direction = 1;
            }
        }
        else if (NPC.type == ModContent.NPCType<MatterMan>())
        {
            float num29 = 3f;
            num29 *= 1f + (1f - NPC.scale);
            if (NPC.velocity.X < -num29 || NPC.velocity.X > num29)
            {
                if (NPC.velocity.Y == 0f)
                {
                    NPC.velocity *= 0.8f;
                }
            }
            else if (NPC.velocity.X < num29 && NPC.direction == 1)
            {
                NPC.velocity.X = NPC.velocity.X + 0.07f;
                if (NPC.velocity.X > num29)
                {
                    NPC.velocity.X = num29;
                }
            }
            else if (NPC.velocity.X > -num29 && NPC.direction == -1)
            {
                NPC.velocity.X = NPC.velocity.X - 0.07f;
                if (NPC.velocity.X < -num29)
                {
                    NPC.velocity.X = -num29;
                }
            }
        }
        else if (NPC.type != 110 && NPC.type != 111 && NPC.type != 206 && NPC.type != 214 && NPC.type != 215 && NPC.type != 216 && NPC.type != 290 && NPC.type != 291 && NPC.type != 292 && NPC.type != 293 && NPC.type != 350 && NPC.type != 387)
        {
            float num39 = 1f;
            if (NPC.type == 186)
            {
                num39 = 1.1f;
            }
            if (NPC.type == 187)
            {
                num39 = 0.9f;
            }
            if (NPC.type == 188)
            {
                num39 = 1.2f;
            }
            if (NPC.type == 189)
            {
                num39 = 0.8f;
            }
            if (NPC.type == 132)
            {
                num39 = 0.95f;
            }
            if (NPC.type == 200)
            {
                num39 = 0.87f;
            }
            if (NPC.type == 223)
            {
                num39 = 1.05f;
            }
            if (NPC.type == 3 || NPC.type == 132 || NPC.type == 186 || NPC.type == 187 || NPC.type == 188 || NPC.type == 189 || NPC.type == 200 || NPC.type == 223 || NPC.type == 331 || NPC.type == 332)
            {
                num39 *= 1f + (1f - NPC.scale);
            }
            if (NPC.velocity.X < -num39 || NPC.velocity.X > num39)
            {
                if (NPC.velocity.Y == 0f)
                {
                    NPC.velocity *= 0.8f;
                }
            }
            else if (NPC.velocity.X < num39 && NPC.direction == 1)
            {
                NPC.velocity.X = NPC.velocity.X + 0.07f;
                if (NPC.velocity.X > num39)
                {
                    NPC.velocity.X = num39;
                }
            }
            else if (NPC.velocity.X > -num39 && NPC.direction == -1)
            {
                NPC.velocity.X = NPC.velocity.X - 0.07f;
                if (NPC.velocity.X < -num39)
                {
                    NPC.velocity.X = -num39;
                }
            }
        }
        bool flag11 = false;
        if (NPC.velocity.Y == 0f)
        {
            int num93 = (int)(NPC.position.Y + (float)NPC.height + 7f) / 16;
            int num94 = (int)NPC.position.X / 16;
            int num95 = (int)(NPC.position.X + (float)NPC.width) / 16;
            for (int num96 = num94; num96 <= num95; num96++)
            {
                if (Main.tile[num96, num93] == null)
                {
                    return;
                }
                if (Main.tile[num96, num93].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[num96, num93].TileType])
                {
                    flag11 = true;
                    break;
                }
            }
        }
        if (NPC.velocity.Y >= 0f)
        {
            int num97 = 0;
            if (NPC.velocity.X < 0f)
            {
                num97 = -1;
            }
            if (NPC.velocity.X > 0f)
            {
                num97 = 1;
            }
            Vector2 vector10 = NPC.position;
            vector10.X += NPC.velocity.X;
            int num98 = (int)((vector10.X + (float)(NPC.width / 2) + (float)((NPC.width / 2 + 1) * num97)) / 16f);
            int num99 = (int)((vector10.Y + (float)NPC.height - 1f) / 16f);
            //if (Main.tile[num98, num99] == null)
            //{
            //    Main.tile[num98, num99] = default(Tile);
            //}
            //if (Main.tile[num98, num99 - 1] == null)
            //{
            //    Main.tile[num98, num99 - 1] = default(Tile);
            //}
            //if (Main.tile[num98, num99 - 2] == null)
            //{
            //    Main.tile[num98, num99 - 2] = default(Tile);
            //}
            //if (Main.tile[num98, num99 - 3] == null)
            //{
            //    Main.tile[num98, num99 - 3] = default(Tile);
            //}
            //if (Main.tile[num98, num99 + 1] == null)
            //{
            //    Main.tile[num98, num99 + 1] = default(Tile);
            //}
            //if (Main.tile[num98 - num97, num99 - 3] == null)
            //{
            //    Main.tile[num98 - num97, num99 - 3] = default(Tile);
            //}
            if ((float)(num98 * 16) < vector10.X + (float)NPC.width && (float)(num98 * 16 + 16) > vector10.X && ((Main.tile[num98, num99].HasUnactuatedTile && !Main.tile[num98, num99].TopSlope && !Main.tile[num98, num99 - 1].TopSlope && Main.tileSolid[(int)Main.tile[num98, num99].TileType] && !Main.tileSolidTop[(int)Main.tile[num98, num99].TileType]) || (Main.tile[num98, num99 - 1].IsHalfBlock && Main.tile[num98, num99 - 1].HasUnactuatedTile)) && (!Main.tile[num98, num99 - 1].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98, num99 - 1].TileType] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 1].TileType] || (Main.tile[num98, num99 - 1].IsHalfBlock && (!Main.tile[num98, num99 - 4].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98, num99 - 4].TileType] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 4].TileType]))) && (!Main.tile[num98, num99 - 2].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98, num99 - 2].TileType] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 2].TileType]) && (!Main.tile[num98, num99 - 3].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98, num99 - 3].TileType] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 3].TileType]) && (!Main.tile[num98 - num97, num99 - 3].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98 - num97, num99 - 3].TileType]))
            {
                float num100 = (float)(num99 * 16);
                if (Main.tile[num98, num99].IsHalfBlock)
                {
                    num100 += 8f;
                }
                if (Main.tile[num98, num99 - 1].IsHalfBlock)
                {
                    num100 -= 8f;
                }
                if (num100 < vector10.Y + (float)NPC.height)
                {
                    float num101 = vector10.Y + (float)NPC.height - num100;
                    float num102 = 16.1f;
                    if (NPC.type == 163 || NPC.type == 164 || NPC.type == 236 || NPC.type == 239)
                    {
                        num102 += 8f;
                    }
                    if (num101 <= num102)
                    {
                        NPC.gfxOffY += NPC.position.Y + (float)NPC.height - num100;
                        NPC.position.Y = num100 - (float)NPC.height;
                        if (num101 < 9f)
                        {
                            NPC.stepSpeed = 1f;
                        }
                        else
                        {
                            NPC.stepSpeed = 2f;
                        }
                    }
                }
            }
        }
        if (flag11)
        {
            int num103 = (int)((NPC.position.X + (float)(NPC.width / 2) + (float)(15 * NPC.direction)) / 16f);
            int num104 = (int)((NPC.position.Y + (float)NPC.height - 15f) / 16f);
            if (NPC.type == 109 || NPC.type == 163 || NPC.type == 164 || NPC.type == 199 || NPC.type == 236 || NPC.type == 239 || NPC.type == 257 || NPC.type == 258 || NPC.type == 290)
            {
                num103 = (int)((NPC.position.X + (float)(NPC.width / 2) + (float)((NPC.width / 2 + 16) * NPC.direction)) / 16f);
            }
            //if (Main.tile[num103, num104] == null)
            //{
            //    Main.tile[num103, num104] = new Tile();
            //}
            //if (Main.tile[num103, num104 - 1] == null)
            //{
            //    Main.tile[num103, num104 - 1] = new Tile();
            //}
            //if (Main.tile[num103, num104 - 2] == null)
            //{
            //    Main.tile[num103, num104 - 2] = new Tile();
            //}
            //if (Main.tile[num103, num104 - 3] == null)
            //{
            //    Main.tile[num103, num104 - 3] = new Tile();
            //}
            //if (Main.tile[num103, num104 + 1] == null)
            //{
            //    Main.tile[num103, num104 + 1] = new Tile();
            //}
            //if (Main.tile[num103 + NPC.direction, num104 - 1] == null)
            //{
            //    Main.tile[num103 + NPC.direction, num104 - 1] = new Tile();
            //}
            //if (Main.tile[num103 + NPC.direction, num104 + 1] == null)
            //{
            //    Main.tile[num103 + NPC.direction, num104 + 1] = new Tile();
            //}
            //if (Main.tile[num103 - NPC.direction, num104 + 1] == null)
            //{
            //    Main.tile[num103 - NPC.direction, num104 + 1] = new Tile();
            //}
            if (Main.tile[num103, num104 - 1].HasUnactuatedTile && (Main.tile[num103, num104 - 1].TileType == 10 || Main.tile[num103, num104 - 1].TileType == 485) && flag5)
            {
                NPC.ai[2] += 1f;
                NPC.ai[3] = 0f;
                if (NPC.ai[2] >= 60f)
                {
                    if (!Main.bloodMoon && (NPC.type == 3 || NPC.type == 331 || NPC.type == 332 || NPC.type == 132 || NPC.type == 161 || NPC.type == 186 || NPC.type == 187 || NPC.type == 188 || NPC.type == 189 || NPC.type == 200 || NPC.type == 223 || NPC.type == 320 || NPC.type == 321 || NPC.type == 319))
                    {
                        NPC.ai[1] = 0f;
                    }
                    NPC.velocity.X = 0.5f * (float)(-(float)NPC.direction);
                    NPC.ai[1] += 5f;
                    if (NPC.type == 27)
                    {
                        NPC.ai[1] += 1f;
                    }
                    if (NPC.type == 31 || NPC.type == 294 || NPC.type == 295 || NPC.type == 296 || NPC.type == 482)
                    {
                        NPC.ai[1] += 6f;
                    }
                    NPC.ai[2] = 0f;
                    bool flag12 = false;
                    if (NPC.ai[1] >= 10f)
                    {
                        flag12 = true;
                        NPC.ai[1] = 10f;
                    }
                    WorldGen.KillTile(num103, num104 - 1, true, false, false);
                    if ((Main.netMode != 1 || !flag12) && flag12 && Main.netMode != 1)
                    {
                        if (NPC.type == 26)
                        {
                            WorldGen.KillTile(num103, num104 - 1, false, false, false);
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendData(17, -1, -1, NetworkText.Empty, 0, (float)num103, (float)(num104 - 1), 0f, 0);
                            }
                        }
                        else
                        {
                            bool flag13 = WorldGen.OpenDoor(num103, num104 - 1, NPC.direction);
                            if (!flag13)
                            {
                                NPC.ai[3] = (float)num22;
                                NPC.netUpdate = true;
                            }
                            if (Main.netMode == 2 && flag13)
                            {
                                NetMessage.SendData(19, -1, -1, NetworkText.Empty, 0, (float)num103, (float)(num104 - 1), (float)NPC.direction, 0);
                            }
                        }
                    }
                }
            }
            else
            {
                if ((NPC.velocity.X < 0f && NPC.spriteDirection == -1) || (NPC.velocity.X > 0f && NPC.spriteDirection == 1))
                {
                    if (Main.tile[num103, num104 - 2].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[num103, num104 - 2].TileType])
                    {
                        if (Main.tile[num103, num104 - 3].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[num103, num104 - 3].TileType])
                        {
                            NPC.velocity.Y = -8f;
                            NPC.netUpdate = true;
                        }
                        else
                        {
                            NPC.velocity.Y = -7f;
                            NPC.netUpdate = true;
                        }
                    }
                    else if (Main.tile[num103, num104 - 1].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[num103, num104 - 1].TileType])
                    {
                        NPC.velocity.Y = -6f;
                        NPC.netUpdate = true;
                    }
                    else if (NPC.position.Y + (float)NPC.height - (float)(num104 * 16) > 20f && Main.tile[num103, num104].HasUnactuatedTile && !Main.tile[num103, num104].TopSlope && Main.tileSolid[(int)Main.tile[num103, num104].TileType])
                    {
                        NPC.velocity.Y = -5f;
                        NPC.netUpdate = true;
                    }
                    else if (NPC.directionY < 0 && NPC.type != 67 && (!Main.tile[num103, num104 + 1].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num103, num104 + 1].TileType]) && (!Main.tile[num103 + NPC.direction, num104 + 1].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num103 + NPC.direction, num104 + 1].TileType]))
                    {
                        NPC.velocity.Y = -8f;
                        NPC.velocity.X = NPC.velocity.X * 1.5f;
                        NPC.netUpdate = true;
                    }
                    else if (flag5)
                    {
                        NPC.ai[1] = 0f;
                        NPC.ai[2] = 0f;
                    }
                    if (NPC.velocity.Y == 0f && flag3 && NPC.ai[3] == 1f)
                    {
                        NPC.velocity.Y = -5f;
                    }
                }
            }
        }
        else if (flag5)
        {
            NPC.ai[1] = 0f;
            NPC.ai[2] = 0f;
        }
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.player.Avalon().ZoneDarkMatter && !spawnInfo.player.InPillarZone() && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode)
        {
            return 1f;
        }
        return 0f;
    }

    public override void FindFrame(int frameHeight)
    {
        if (NPC.velocity.X > 0f)
        {
            NPC.spriteDirection = 1;
        }
        if (NPC.velocity.X < 0f)
        {
            NPC.spriteDirection = -1;
        }
        NPC.frameCounter += 1.0;
        if (NPC.frameCounter >= 6.0)
        {
            NPC.frame.Y = NPC.frame.Y + frameHeight;
            NPC.frameCounter = 0.0;
        }
        if (NPC.frame.Y >= frameHeight * Main.npcFrameCount[NPC.type])
        {
            NPC.frame.Y = 0;
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("MatterManHead").Type, 1f);
        }
    }
}
