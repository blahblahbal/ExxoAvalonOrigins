﻿using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Reflection;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Hooks
{
    class Tropics
    {
        public static void ILFindStart(ILContext il)
        {
            Utils.AddAlternativeIDCheck(il, TileID.Mud, (ushort)ModContent.TileType<Tiles.TropicalMud>());
            Utils.AddAlternativeIDCheck(il, TileID.JungleGrass, (ushort)ModContent.TileType<Tiles.TropicalGrass>());
        }
        public static void ILGenPassDirtWallBackgrounds(ILContext il)
        {
            Utils.AddAlternativeIDCheck(il, WallID.JungleUnsafe, (ushort)ModContent.WallType<Walls.TropicalGrassWall>());
        }
        public static void ILGenPassJungle(ILContext il)
        {
            //Utils.AddAlternativeIDCheck(il, TileID.Mud, (ushort)ModContent.TileType<Tiles.TropicalMud>());
            ReplaceIDIfTropics(il, TileID.Mud, (ushort)ModContent.TileType<Tiles.TropicalMud>());

            Utils.AddAlternativeIDCheck(il, WallID.JungleUnsafe, (ushort)ModContent.WallType<Walls.TropicalGrassWall>());
            Utils.AddAlternativeIDCheck(il, WallID.MudUnsafe, (ushort)ModContent.WallType<Walls.TropicalMudWall>());
        }
        public static void ILGrowUndergroundTree(ILContext il)
        {
            Utils.AddAlternativeIDCheck(il, TileID.JungleGrass, (ushort)ModContent.TileType<Tiles.TropicalGrass>());
        }
        public static void ILTileRunner(ILContext il)
        {
            Utils.AddAlternativeIDCheck(il, TileID.Mud, (ushort)ModContent.TileType<Tiles.TropicalMud>());

            //Utils.AddAlternativeIDCheck(il, WallID.JungleUnsafe, (ushort)ModContent.WallType<Walls.TropicalGrassWall>());
            ReplaceIDIfTropics(il, WallID.JungleUnsafe, (ushort)ModContent.WallType<Walls.TropicalGrassWall>());

            //Utils.AddAlternativeIDCheck(il, WallID.MudUnsafe, (ushort)ModContent.WallType<Walls.TropicalMudWall>());
            ReplaceIDIfTropics(il, WallID.MudUnsafe, (ushort)ModContent.WallType<Walls.TropicalMudWall>());
        }
        public static void ILCleanUpDirt(ILContext il)
        {
            Utils.AddAlternativeIDCheck(il, WallID.JungleUnsafe, (ushort)ModContent.WallType<Walls.TropicalGrassWall>());
            Utils.AddAlternativeIDCheck(il, TileID.Crimsand, (ushort)ModContent.TileType<Tiles.Snotsand>());
        }
        public static void ILWetJungle(ILContext il)
        {
            Utils.AddAlternativeIDCheck(il, TileID.JungleGrass, (ushort)ModContent.TileType<Tiles.TropicalGrass>());
        }
        public static void ILJunglePlants(ILContext il)
        {
            Utils.AddAlternativeIDCheck(il, TileID.JungleGrass, (ushort)ModContent.TileType<Tiles.TropicalGrass>());
        }
        public static void ILMudCavesToGrass(ILContext il)
        {
            Utils.AddAlternativeIDCheck(il, TileID.JungleGrass, (ushort)ModContent.TileType<Tiles.TropicalGrass>());
        }
        public static void ILMudWallsInJungle(ILContext il)
        {
            Utils.AddAlternativeIDCheck(il, TileID.Mud, (ushort)ModContent.TileType<Tiles.TropicalMud>());
            Utils.AddAlternativeIDCheck(il, TileID.JungleGrass, (ushort)ModContent.TileType<Tiles.TropicalGrass>());
            ReplaceIDIfTropics(il, WallID.MudUnsafe, (ushort)ModContent.WallType<Walls.TropicalMudWall>());
        }
        public static void ILWallVariety(ILContext il)
        {
            Utils.AddAlternativeIDCheck(il, TileID.Mud, (ushort)ModContent.TileType<Tiles.TropicalMud>());
            ReplaceIDIfTropics(il, TileID.JungleGrass, (ushort)ModContent.TileType<Tiles.TropicalGrass>());
        }
        public static void ILIceWalls(ILContext il)
        {
            Utils.AddAlternativeIDCheck(il, WallID.JungleUnsafe, (ushort)ModContent.WallType<Walls.TropicalGrassWall>());
            ReplaceIDIfTropics(il, WallID.MudUnsafe, (ushort)ModContent.WallType<Walls.TropicalMudWall>());
        }
        public static void ILGrassWall(ILContext il)
        {
            Utils.AddAlternativeIDCheck(il, WallID.MudUnsafe, (ushort)ModContent.WallType<Walls.TropicalMudWall>());
        }
        public static void ILSpreadWall(ILContext il)
        {
            Instruction loadWall = Instruction.Create(OpCodes.Ldloc_0);
            Instruction loadWallType = Instruction.Create(OpCodes.Ldarg_2);

            Utils.SoftReplaceAllMatchingInstructions(il, loadWall, loadWallType);
        }
        public static void ILSpreadWall2(ILContext il)
        {
            Instruction loadB = Instruction.Create(OpCodes.Ldloc_0);
            Instruction loadWallType = Instruction.Create(OpCodes.Ldarg_2);

            Utils.SoftReplaceAllMatchingInstructions(il, loadB, loadWallType);
        }
        public static void OnSpreadGrass(On.Terraria.WorldGen.orig_SpreadGrass orig, int i, int j, int dirt, int grass, bool repeat, byte color)
        {
            if (ExxoAvalonOriginsWorld.jungleMenuSelection == ExxoAvalonOriginsWorld.JungleVariant.tropics)
            {
                if (dirt == TileID.Mud && grass != TileID.MushroomGrass)
                {
                    dirt = ModContent.TileType<Tiles.TropicalMud>();
                }
                if (grass == TileID.JungleGrass)
                {
                    grass = ModContent.TileType<Tiles.TropicalGrass>();
                }
            }
            orig(i, j, dirt, grass, repeat, color);
        }
        private static void ReplaceIDIfTropics(ILContext il, ushort val1, ushort val2)
        {
            Utils.ReplaceIDIfMatch(il, val1, val2, typeof(ExxoAvalonOriginsWorld).GetField("jungleMenuSelection", BindingFlags.Public | BindingFlags.Static), (int)ExxoAvalonOriginsWorld.JungleVariant.tropics);
        }
    }
}
