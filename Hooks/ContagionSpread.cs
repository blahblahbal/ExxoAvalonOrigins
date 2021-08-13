using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using ExxoAvalonOrigins.Tiles;
using Terraria.ID;

namespace ExxoAvalonOrigins.Hooks
{
    class ContagionSpread
    {
        public static void ILHardUpdateWorld(ILContext il)
        {
            var c = new ILCursor(il);

            // --- CONTAGION SPREAD HARDMODE ---

            // Move il cursor into positon
            if (!c.TryGotoNext(i => i.MatchLdsfld<NPC>(nameof(NPC.downedPlantBoss))))
                return;
            if (!c.TryGotoNext(MoveType.After, i => i.MatchRet()))
                return;

            // Automatically shift cursor after each emit
            c.MoveAfterLabels();

            // Load local variables to stack
            c.Emit(OpCodes.Ldloc_0);
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);

            // Emit custom logic
            c.EmitDelegate<Action<int, int, int>>((type, i, j) =>
            {
                //if (ExxoAvalonOrigins.superHardmode)
                //{
                //    if (type == ModContent.TileType<Tiles.DarkMatter>() || type == ModContent.TileType<Tiles.DarkMatterSoil>() || type == ModContent.TileType<DarkMatterGrass>() || type == ModContent.TileType<DarkMatterSand>() || type == ModContent.TileType<HardenedDarkSand>() || type == ModContent.TileType<Darksandstone>() || type == ModContent.TileType<BlackIce>())
                //    {
                //        bool flag5 = true;
                //        while (flag5)
                //        {
                //            flag5 = false;
                //            int num6 = i + WorldGen.genRand.Next(-3, 4);
                //            int num7 = j + WorldGen.genRand.Next(-3, 4);
                //            //bool flag6 = NearbyChlorophyte(num6, num7);
                //            if (Main.tile[num6, num7 - 1].type == 27)
                //            {
                //                continue;
                //            }
                //            if (Main.tile[num6, num7].type == 2)
                //            {
                //                if (WorldGen.genRand.Next(2) == 0)
                //                {
                //                    flag5 = true;
                //                }
                //                Main.tile[num6, num7].type = (ushort)ModContent.TileType<Ickgrass>();
                //                WorldGen.SquareTileFrame(num6, num7);
                //                NetMessage.SendTileSquare(-1, num6, num7, 1);
                //            }
                //            else if (Main.tile[num6, num7].type == TileID.Stone || Main.tile[num6, num7].type == TileID.Crimstone || Main.tile[num6, num7].type == TileID.Ebonstone || Main.tile[num6, num7].type == TileID.Pearlstone || Main.tile[num6, num7].type == (ushort)ModContent.TileType<Chunkstone>() || Main.tileMoss[Main.tile[num6, num7].type])
                //            {
                //                if (WorldGen.genRand.Next(2) == 0)
                //                {
                //                    flag5 = true;
                //                }
                //                Main.tile[num6, num7].type = (ushort)ModContent.TileType<DarkMatter>();
                //                WorldGen.SquareTileFrame(num6, num7);
                //                NetMessage.SendTileSquare(-1, num6, num7, 1);
                //            }
                //            else if (Main.tile[num6, num7].type == TileID.Sand || Main.tile[num6, num7].type == TileID.Pearlsand || Main.tile[num6, num7].type == TileID.Ebonsand || Main.tile[num6, num7].type == TileID.Crimsand || Main.tile[num6, num7].type == (ushort)ModContent.TileType<Snotsand>())
                //            {
                //                if (WorldGen.genRand.Next(2) == 0)
                //                {
                //                    flag5 = true;
                //                }
                //                Main.tile[num6, num7].type = (ushort)ModContent.TileType<Tiles.DarkMatterSand>();
                //                WorldGen.SquareTileFrame(num6, num7);
                //                NetMessage.SendTileSquare(-1, num6, num7, 1);
                //            }
                //            else if (Main.tile[num6, num7].type == TileID.Sandstone || Main.tile[num6, num7].type == TileID.CrimsonSandstone || Main.tile[num6, num7].type == TileID.CorruptSandstone || Main.tile[num6, num7].type == TileID.HallowSandstone || Main.tile[num6, num7].type == (ushort)ModContent.TileType<Snotsandstone>())
                //            {
                //                if (WorldGen.genRand.Next(2) == 0)
                //                {
                //                    flag5 = true;
                //                }
                //                Main.tile[num6, num7].type = (ushort)ModContent.TileType<Darksandstone>();
                //                WorldGen.SquareTileFrame(num6, num7);
                //                NetMessage.SendTileSquare(-1, num6, num7, 1);
                //            }
                //            else if (Main.tile[num6, num7].type == TileID.HardenedSand || Main.tile[num6, num7].type == TileID.CrimsonHardenedSand || Main.tile[num6, num7].type == TileID.CorruptHardenedSand || Main.tile[num6, num7].type == TileID.HallowHardenedSand || Main.tile[num6, num7].type == (ushort)ModContent.TileType<HardenedSnotsand>())
                //            {
                //                if (WorldGen.genRand.Next(2) == 0)
                //                {
                //                    flag5 = true;
                //                }
                //                Main.tile[num6, num7].type = (ushort)ModContent.TileType<HardenedDarkSand>();
                //                WorldGen.SquareTileFrame(num6, num7);
                //                NetMessage.SendTileSquare(-1, num6, num7, 1);
                //            }
                //            else if (Main.tile[num6, num7].type == TileID.IceBlock || Main.tile[num6, num7].type == TileID.FleshIce || Main.tile[num6, num7].type == TileID.CorruptIce || Main.tile[num6, num7].type == TileID.HallowedIce || Main.tile[num6, num7].type == (ushort)ModContent.TileType<YellowIce>())
                //            {
                //                if (WorldGen.genRand.Next(2) == 0)
                //                {
                //                    flag5 = true;
                //                }
                //                Main.tile[num6, num7].type = (ushort)ModContent.TileType<BlackIce>();
                //                WorldGen.SquareTileFrame(num6, num7);
                //                NetMessage.SendTileSquare(-1, num6, num7, 1);
                //            }
                //        }
                //    }
                //}
                if (type == ModContent.TileType<Tiles.Chunkstone>() || type == ModContent.TileType<Ickgrass>() || type == ModContent.TileType<Snotsand>() || type == ModContent.TileType<HardenedSnotsand>() || type == ModContent.TileType<Snotsandstone>() || type == ModContent.TileType<YellowIce>())
                {
                    bool flag5 = true;
                    while (flag5)
                    {
                        flag5 = false;
                        int num6 = i + WorldGen.genRand.Next(-3, 4);
                        int num7 = j + WorldGen.genRand.Next(-3, 4);
                        //bool flag6 = NearbyChlorophyte(num6, num7);
                        if (Main.tile[num6, num7 - 1].type == 27)
                        {
                            continue;
                        }
                        if (Main.tile[num6, num7].type == 2)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                flag5 = true;
                            }
                            Main.tile[num6, num7].type = (ushort)ModContent.TileType<Ickgrass>();
                            WorldGen.SquareTileFrame(num6, num7);
                            NetMessage.SendTileSquare(-1, num6, num7, 1);
                        }
                        else if (Main.tile[num6, num7].type == 1 || Main.tileMoss[Main.tile[num6, num7].type])
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                flag5 = true;
                            }
                            Main.tile[num6, num7].type = (ushort)ModContent.TileType<Chunkstone>();
                            WorldGen.SquareTileFrame(num6, num7);
                            NetMessage.SendTileSquare(-1, num6, num7, 1);
                        }
                        else if (Main.tile[num6, num7].type == 53)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                flag5 = true;
                            }
                            Main.tile[num6, num7].type = (ushort)ModContent.TileType<Snotsand>();
                            WorldGen.SquareTileFrame(num6, num7);
                            NetMessage.SendTileSquare(-1, num6, num7, 1);
                        }
                        else if (Main.tile[num6, num7].type == 396)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                flag5 = true;
                            }
                            Main.tile[num6, num7].type = (ushort)ModContent.TileType<Snotsandstone>();
                            WorldGen.SquareTileFrame(num6, num7);
                            NetMessage.SendTileSquare(-1, num6, num7, 1);
                        }
                        else if (Main.tile[num6, num7].type == 397)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                flag5 = true;
                            }
                            Main.tile[num6, num7].type = (ushort)ModContent.TileType<HardenedSnotsand>();
                            WorldGen.SquareTileFrame(num6, num7);
                            NetMessage.SendTileSquare(-1, num6, num7, 1);
                        }
                        else if (Main.tile[num6, num7].type == 161)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                flag5 = true;
                            }
                            Main.tile[num6, num7].type = (ushort)ModContent.TileType<YellowIce>();
                            WorldGen.SquareTileFrame(num6, num7);
                            NetMessage.SendTileSquare(-1, num6, num7, 1);
                        }
                    }
                }
            });
            // --- END OF CONTAGION SPREAD HARDMODE ---
        }
    }
}
