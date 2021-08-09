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
