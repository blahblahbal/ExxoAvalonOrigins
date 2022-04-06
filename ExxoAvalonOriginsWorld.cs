using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Seed;
using ExxoAvalonOrigins.Logic;
using ExxoAvalonOrigins.Tiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using Terraria.WorldBuilding;
using Utils = ExxoAvalonOrigins.World.Utils;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.UI;

namespace ExxoAvalonOrigins;

public class ExxoAvalonOriginsWorld : ModSystem
{
    private Version worldVersion;
    public bool SuperHardmode { get; private set; }

    public static int shmOreTier1 = -1;
    public static int shmOreTier2 = -1;
    public static int hallowAltarCount;
    public static bool contagion = false;
    public static int WorldDarkMatterTiles = 0;
    public static int hallowedAltarCount = 0;
    public static bool stopCometDrops = false;
    public static Vector2 hiddenTemplePos;
    public static bool retroGenned = false;
    public static bool jungleLocationKnown = false;
    public static bool generatingBaccilite = false;
    public static int dungeonSide = 0;
    public static int jungleX = 0;
    public static int grassSpread = 0;
    public static bool contaigonSet = false;
    public static Vector2 LoK = Vector2.Zero;
    public static int wosT;
    public static int wosB;
    public static int wosF = 0;
    public static int wos = -1;
    public static bool downedBacteriumPrime = false;
    public static bool downedDesertBeak = false;
    public static bool downedPhantasm = false;
    public static bool downedDragonLord = false;
    public static bool downedMechasting = false;
    public static bool oblivionDead = false;
    public static bool downedKingSting = false;
    public static bool stoppedArmageddon = false;
    public static int specialWireHitCount = 0;

    #region WorldGen Variants

    public enum JungleVariant
    {
        jungle,
        tropics,
        random
    }

    public enum CopperVariant
    {
        copper,
        tin,
        bronze,
        random
    }

    public enum IronVariant
    {
        iron,
        lead,
        nickel,
        random
    }

    public enum SilverVariant
    {
        silver,
        tungsten,
        zinc,
        random
    }

    public enum GoldVariant
    {
        gold,
        platinum,
        bismuth,
        random
    }

    public enum RhodiumVariant
    {
        rhodium,
        osmium,
        iridium,
        random
    }

    public enum CobaltVariant
    {
        cobalt,
        palladium,
        duratanium,
        random
    }

    public enum MythrilVariant
    {
        mythril,
        orichalcum,
        naquadah,
        random
    }

    public enum AdamantiteVariant
    {
        adamantite,
        titanium,
        troxinium,
        random
    }

    public enum SHMTier1Variant
    {
        tritanorium,
        pyroscoric,
        random
    }

    public enum SHMTier2Variant
    {
        unvolandite,
        vorazylcum,
        random
    }

    public static JungleVariant jungleMenuSelection = JungleVariant.random;
    public static CopperVariant copperOre = CopperVariant.random;
    public static IronVariant ironOre = IronVariant.random;
    public static SilverVariant silverOre = SilverVariant.random;
    public static GoldVariant goldOre = GoldVariant.random;
    public static RhodiumVariant rhodiumOre = RhodiumVariant.random;
    public static CobaltVariant cobaltOre = CobaltVariant.random;
    public static MythrilVariant mythrilOre = MythrilVariant.random;
    public static AdamantiteVariant adamantiteOre = AdamantiteVariant.random;
    public static SHMTier1Variant shmTier1Ore = SHMTier1Variant.random;
    public static SHMTier2Variant shmTier2Ore = SHMTier2Variant.random;

    #endregion WorldGen Variants

    //public override void ChooseWaterStyle(ref int style)
    //{
    //    if (Main.LocalPlayer.Avalon().ZoneContagion)
    //    {
    //        style = ModContent.GetInstance<Waters.ContagionWaterStyle>().Type;
    //    }

    //    if (Main.LocalPlayer.Avalon().ZoneTropics)
    //    {
    //        style = ModContent.GetInstance<Waters.TropicsWaterStyle>().Type;
    //    }
    //}
    //public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
    //{
    //    float ickyStrength = ExxoAvalonOriginsWorld.ickyTiles / 800f;
    //    ickyStrength = Math.Min(ickyStrength, 1f);
    //    if (ickyStrength > 0)
    //    {
    //        int sunR = Main.bgColor.R;
    //        int sunG = Main.bgColor.G;
    //        int sunB = Main.bgColor.B;
    //        sunR -= (int)(100f * ickyStrength * (Main.bgColor.R / 255f));
    //        sunG -= (int)(50f * ickyStrength * (Main.bgColor.G / 255f));
    //        sunB -= (int)(80f * ickyStrength * (Main.bgColor.G / 255f));
    //        sunR = Utils.Clamp(sunR, 15, 255);
    //        sunG = Utils.Clamp(sunG, 15, 255);
    //        sunB = Utils.Clamp(sunB, 15, 255);
    //        Main.bgColor.R = (byte)sunR;
    //        Main.bgColor.G = (byte)sunG;
    //        Main.bgColor.B = (byte)sunB;
    //    }
    //}
    public override void PostUpdateEverything()
    {
        Tiles.CoolGemsparkBlock.StaticUpdate();
        Tiles.WarmGemsparkBlock.StaticUpdate();
        Items.Armor.SpectrumHelmet.StaticUpdate();
    }
    public override void PreUpdateEntities()
    {
        if (Main.netMode == NetmodeID.MultiplayerClient)
        {
            Main.tileSolidTop[ModContent.TileType<Tiles.FallenStarTile>()] = Main.dayTime;
        }
    }
    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        layers.Insert(0, new LegacyGameInterfaceLayer(
            "ExxoAvalonOrigins: Update Interfaces",
            delegate
            {
                if (Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herb && Main.playerInventory && ExxoAvalonOrigins.Mod.herbologyUserInterface.CurrentState == null)
                {
                    ExxoAvalonOrigins.Mod.herbologyUserInterface.SetState(ExxoAvalonOrigins.Mod.herbology);
                    typeof(UserInterface).GetField("_clickDisabledTimeRemaining", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(ExxoAvalonOrigins.Mod.herbologyUserInterface, 10);
                }
                else if (!(Main.playerInventory && Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herb) && ExxoAvalonOrigins.Mod.herbologyUserInterface.CurrentState != null)
                {
                    ExxoAvalonOrigins.Mod.herbologyUserInterface.SetState(null);
                }

                ExxoAvalonOrigins.Mod.herbologyUserInterface.Update(Main._drawInterfaceGameTime);
                ExxoAvalonOrigins.Mod.staminaInterface.Update(Main._drawInterfaceGameTime);
                return true;
            },
            InterfaceScaleType.UI)
        );

        int inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Radial Hotbars"));
        if (inventoryIndex >= 0)
        {
            layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
                "ExxoAvalonOrigins: Tome Slot",
                delegate
                {
                    ExxoAvalonOrigins.Mod.tomeSlot.DrawTomes(Main.spriteBatch);
                    return true;
                },
                InterfaceScaleType.UI)
            );

            layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
                "ExxoAvalonOrigins: Herbology Bench",
                delegate
                {
                    ExxoAvalonOrigins.Mod.herbologyUserInterface.Draw(Main.spriteBatch, Main._drawInterfaceGameTime);
                    return true;
                },
                InterfaceScaleType.UI)
            );
        }

        int resourceBarsIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
        if (resourceBarsIndex >= 0)
        {
            layers.Insert(resourceBarsIndex, new LegacyGameInterfaceLayer(
                "ExxoAvalonOrigins: Stamina Bar",
                delegate
                {
                    ExxoAvalonOrigins.Mod.staminaInterface.Draw(Main.spriteBatch, Main._drawInterfaceGameTime);
                    return true;
                },
                InterfaceScaleType.UI)
            );
        }
    }
    public static bool AnyTiles(Player player, ushort type, int distance = 20, bool candle = true)
    {
        Point tileC = player.position.ToTileCoordinates();
        for (int x = tileC.X - distance; x < tileC.X + distance; x++)
        {
            for (int y = tileC.Y - distance; y < tileC.Y + distance; y++)
            {
                if (Main.tile[x, y].TileType == type && (candle ? Main.tile[x, y].TileFrameX == 0 : true)) return true;
            }
        }
        return false;
    }

    public void RetroGen()
    {
        if (worldVersion < new Version(0, 1, 0, 0))
        {
            rhodiumOre = (RhodiumVariant)WorldGen.genRand.Next(2);
            for (int num156 = 0; num156 < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); num156++)
            {
                int i10 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                double rockLayer3 = Main.rockLayer;
                int j10 = WorldGen.genRand.Next((int)rockLayer3, Main.maxTilesY - 150);
                WorldGen.OreRunner(i10, j10, WorldGen.genRand.Next(4, 5), WorldGen.genRand.Next(5, 7), (ushort)rhodiumOre.GetTile());
            }
            Main.NewText("Retrogenned Rhodium/Osmium/Iridium");
        }
        if (worldVersion < new Version(0, 1, 1, 0))
        {
            for (int num284 = 69; num284 < 72; num284++)
            {
                int type8 = 0;
                float num285 = 0;
                if (num284 == 69)
                {
                    type8 = ModContent.TileType<Tiles.Ores.Tourmaline>();
                    num285 = Main.maxTilesX * 0.2f;
                }
                else if (num284 == 70)
                {
                    type8 = ModContent.TileType<Tiles.Ores.Peridot>();
                    num285 = Main.maxTilesX * 0.2f;
                }
                else if (num284 == 71)
                {
                    type8 = ModContent.TileType<Tiles.Ores.Zircon>();
                    num285 = Main.maxTilesX * 0.2f;
                }
                num285 *= 0.2f;
                int num286 = 0;
                while (num286 < num285)
                {
                    int num287 = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                    while (Main.tile[num287, num288].TileType != 1)
                    {
                        num287 = WorldGen.genRand.Next(0, Main.maxTilesX);
                        num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                    }
                    WorldGen.TileRunner(num287, num288, WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), type8, false, 0f, 0f, false, true);
                    num286++;
                }
            }
            Main.NewText("Retrogenned Tourmaline, Peridot and Zircon");
        }
        if (worldVersion < new Version(0, 3, 0, 0))
        {
            for (int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 2E-05); i++)
            {
                int i8 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                double rockLayer = Main.rockLayer;
                int j8 = WorldGen.genRand.Next((int)rockLayer, Main.maxTilesY - 150);
                World.Passes.OreGenPreHardMode.GenerateHearts(i8, j8, ModContent.TileType<Tiles.Ores.Heartstone>());
            }
            Main.NewText("Retrogenned Heartstone");
        }
        if (worldVersion < new Version(0, 3, 0, 0))
        {
            for (int num721 = 0; num721 < 3; num721++)
            {
                int x10 = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                int y6 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 300);
                World.Structures.IceShrine.Generate(x10, y6);
            }
            Main.NewText("Retrogenned Ice Shrines");
        }
    }

    public static void CheckLargeHerb(int x, int y, int type)
    {
        if (WorldGen.destroyObject)
        {
            return;
        }
        Tile t = Main.tile[x, y];
        int style = t.TileFrameX / 18;
        bool destroy = false;
        int fixedY = y;
        int yframe = Main.tile[x, y].TileFrameY;
        fixedY -= yframe / 18;
        if (!WorldGen.SolidTile2(x, fixedY + 3) || !Main.tile[x, fixedY].HasTile ||
            !Main.tile[x, fixedY + 1].HasTile || !Main.tile[x, fixedY + 2].HasTile)
        {
            destroy = true;
        }
        if (destroy)
        {
            WorldGen.destroyObject = true;
            for (int u = fixedY; u < fixedY + 3; u++)
            {
                WorldGen.KillTile(x, u, false, false, false);
            }
            if (type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage1>() || type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>() ||
                type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>()) // 469 through 471 are the immature tiles of the large herb; 472 is the mature version
            {
                int item = 0;
                switch (style)
                {
                    case 0:
                        item = ModContent.ItemType<LargeDaybloomSeed>();
                        break;
                    case 1:
                        item = ModContent.ItemType<LargeMoonglowSeed>();
                        break;
                    case 2:
                        item = ModContent.ItemType<LargeBlinkrootSeed>();
                        break;
                    case 3:
                        item = ModContent.ItemType<LargeDeathweedSeed>();
                        break;
                    case 4:
                        item = ModContent.ItemType<LargeWaterleafSeed>();
                        break;
                    case 5:
                        item = ModContent.ItemType<LargeFireblossomSeed>();
                        break;
                    case 6:
                        item = ModContent.ItemType<LargeShiverthornSeed>();
                        break;
                    case 7:
                        item = ModContent.ItemType<LargeBloodberrySeed>();
                        break;
                    case 8:
                        item = ModContent.ItemType<LargeSweetstemSeed>();
                        break;
                    case 9:
                        item = ModContent.ItemType<LargeBarfbushSeed>();
                        break;
                    case 10:
                        item = ModContent.ItemType<LargeHolybirdSeed>();
                        break;
                }// 3710 through 3719 are the seeds
                if (item > 0)
                {
                    Item.NewItem(WorldGen.GetItemSource_FromTileBreak(x, y), x * 16, fixedY * 16, 16, 48, item);
                }
            }
            else
            {
                int item = 0;
                switch (style)
                {
                    case 0:
                        item = ModContent.ItemType<LargeDaybloom>();
                        break;
                    case 1:
                        item = ModContent.ItemType<LargeMoonglow>();
                        break;
                    case 2:
                        item = ModContent.ItemType<LargeBlinkroot>();
                        break;
                    case 3:
                        item = ModContent.ItemType<LargeDeathweed>();
                        break;
                    case 4:
                        item = ModContent.ItemType<LargeWaterleaf>();
                        break;
                    case 5:
                        item = ModContent.ItemType<LargeFireblossom>();
                        break;
                    case 6:
                        item = ModContent.ItemType<LargeShiverthorn>();
                        break;
                    case 7:
                        item = ModContent.ItemType<LargeBloodberry>();
                        break;
                    case 8:
                        item = ModContent.ItemType<LargeSweetstem>();
                        break;
                    case 9:
                        item = ModContent.ItemType<LargeBarfbush>();
                        break;
                    case 10:
                        item = ModContent.ItemType<LargeHolybird>();
                        break;
                }
                if (item > 0)
                {
                    Item.NewItem(WorldGen.GetItemSource_FromTileBreak(x, y), x * 16, fixedY * 16, 16, 48, item);
                }
                // 3700 through 3709 are the large herbs
            }
            WorldGen.destroyObject = false;
        }
    }

    public static void BCBConvert(int i, int j, int conversionType, int size = 4)
    {
        for (int k = i - size; k <= i + size; k++)
        {
            for (int l = j - size; l <= j + size; l++)
            {
                if (!WorldGen.InWorld(k, l, 1))
                {
                    continue;
                }
                int type = Main.tile[k, l].TileType;
                int wall = Main.tile[k, l].WallType;
                switch (conversionType)
                {
                    #region crimson (4)
                    case 4: // crimson
                        if (WallID.Sets.Conversion.Grass[wall] && wall != 81)
                        {
                            Main.tile[k, l].WallType = 81;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Stone[wall] && wall != 83)
                        {
                            Main.tile[k, l].WallType = 83;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.HardenedSand[wall] && wall != 218)
                        {
                            Main.tile[k, l].WallType = 218;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Sandstone[wall] && wall != 221)
                        {
                            Main.tile[k, l].WallType = 221;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        if ((Main.tileMoss[type] || TileID.Sets.Conversion.Stone[type]) && type != 203)
                        {
                            Main.tile[k, l].TileType = 203;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Grass[type] && type != 199)
                        {
                            Main.tile[k, l].TileType = 199;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Ice[type] && type != 200)
                        {
                            Main.tile[k, l].TileType = 200;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sand[type] && type != 234)
                        {
                            Main.tile[k, l].TileType = 234;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.HardenedSand[type] && type != 399)
                        {
                            Main.tile[k, l].TileType = 399;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sandstone[type] && type != 401)
                        {
                            Main.tile[k, l].TileType = 401;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Thorn[type] && type != 352)
                        {
                            Main.tile[k, l].TileType = 352;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        if (type == 59 && (Main.tile[k - 1, l].TileType == 199 || Main.tile[k + 1, l].TileType == 199 || Main.tile[k, l - 1].TileType == 199 || Main.tile[k, l + 1].TileType == 199))
                        {
                            Main.tile[k, l].TileType = 0;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        continue;
                    #endregion crimson
                    #region hallow (2)
                    case 2:
                        if (WallID.Sets.Conversion.Grass[wall] && wall != 70)
                        {
                            Main.tile[k, l].WallType = 70;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Stone[wall] && wall != 28)
                        {
                            Main.tile[k, l].WallType = 28;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.HardenedSand[wall] && wall != 219)
                        {
                            Main.tile[k, l].WallType = 219;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Sandstone[wall] && wall != 222)
                        {
                            Main.tile[k, l].WallType = 222;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        if ((Main.tileMoss[type] || TileID.Sets.Conversion.Stone[type]) && type != 117)
                        {
                            Main.tile[k, l].TileType = 117;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Grass[type] && type != 109)
                        {
                            Main.tile[k, l].TileType = 109;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Ice[type] && type != 164)
                        {
                            Main.tile[k, l].TileType = 164;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sand[type] && type != 116)
                        {
                            Main.tile[k, l].TileType = 116;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.HardenedSand[type] && type != 402)
                        {
                            Main.tile[k, l].TileType = 402;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sandstone[type] && type != 403)
                        {
                            Main.tile[k, l].TileType = 403;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Thorn[type])
                        {
                            WorldGen.KillTile(k, l);
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendData(17, -1, -1, null, 0, k, l);
                            }
                        }
                        if (type == 59 && (Main.tile[k - 1, l].TileType == 109 || Main.tile[k + 1, l].TileType == 109 || Main.tile[k, l - 1].TileType == 109 || Main.tile[k, l + 1].TileType == 109))
                        {
                            Main.tile[k, l].TileType = 0;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        continue;
                    #endregion hallow
                    #region corruption (1)
                    case 1:
                        if (WallID.Sets.Conversion.Grass[wall] && wall != 69)
                        {
                            Main.tile[k, l].WallType = 69;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Stone[wall] && wall != 3)
                        {
                            Main.tile[k, l].WallType = 3;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.HardenedSand[wall] && wall != 217)
                        {
                            Main.tile[k, l].WallType = 217;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Sandstone[wall] && wall != 220)
                        {
                            Main.tile[k, l].WallType = 220;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        if ((Main.tileMoss[type] || TileID.Sets.Conversion.Stone[type]) && type != 25)
                        {
                            Main.tile[k, l].TileType = 25;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Grass[type] && type != 23)
                        {
                            Main.tile[k, l].TileType = 23;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Ice[type] && type != 163)
                        {
                            Main.tile[k, l].TileType = 163;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sand[type] && type != 112)
                        {
                            Main.tile[k, l].TileType = 112;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.HardenedSand[type] && type != 398)
                        {
                            Main.tile[k, l].TileType = 398;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sandstone[type] && type != 400)
                        {
                            Main.tile[k, l].TileType = 400;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Thorn[type] && type != 32)
                        {
                            Main.tile[k, l].TileType = 32;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        if (type == 59 && (Main.tile[k - 1, l].TileType == 23 || Main.tile[k + 1, l].TileType == 23 || Main.tile[k, l - 1].TileType == 23 || Main.tile[k, l + 1].TileType == 23))
                        {
                            Main.tile[k, l].TileType = 0;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        continue;
                    #endregion corruption
                    #region mushrooms (3)
                    case 3:
                        if (Main.tile[k, l].WallType == 64 || Main.tile[k, l].WallType == 15)
                        {
                            Main.tile[k, l].WallType = 80;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 3);
                        }
                        if (Main.tile[k, l].TileType == 60)
                        {
                            Main.tile[k, l].TileType = 70;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 3);
                        }
                        else if (TileID.Sets.Conversion.Thorn[type])
                        {
                            WorldGen.KillTile(k, l);
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendData(17, -1, -1, null, 0, k, l);
                            }
                        }
                        continue;
                    #endregion mushrooms
                    #region jungle (5)
                    case 5:
                        if (WallID.Sets.Conversion.Grass[wall] && wall != WallID.JungleUnsafe2)
                        {
                            Main.tile[k, l].WallType = WallID.JungleUnsafe2;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Stone[wall] && wall != WallID.MudUnsafe)
                        {
                            Main.tile[k, l].WallType = WallID.MudUnsafe;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.HardenedSand[wall] && wall != WallID.JungleUnsafe1)
                        {
                            Main.tile[k, l].WallType = WallID.JungleUnsafe1;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Sandstone[wall] && wall != WallID.JungleUnsafe)
                        {
                            Main.tile[k, l].WallType = WallID.JungleUnsafe;
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        if ((Main.tileMoss[type] || TileID.Sets.Conversion.Stone[type]) && type != 1)
                        {
                            Main.tile[k, l].TileType = 1;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (type == 0 || type == ModContent.TileType<TropicalMud>())
                        {
                            Main.tile[k, l].TileType = 59;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Grass[type] && type != 60)
                        {
                            Main.tile[k, l].TileType = 60;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Ice[type] && type != (ushort)ModContent.TileType<GreenIce>())
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<GreenIce>();
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sand[type] && type != 53)
                        {
                            Main.tile[k, l].TileType = 53;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.HardenedSand[type] && type != TileID.HardenedSand)
                        {
                            Main.tile[k, l].TileType = TileID.HardenedSand;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sandstone[type] && type != TileID.Sandstone)
                        {
                            Main.tile[k, l].TileType = TileID.Sandstone;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Thorn[type] && type != TileID.JungleThorns)
                        {
                            Main.tile[k, l].TileType = TileID.JungleThorns;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        continue;
                    #endregion jungle
                    #region contagion (6)
                    case 6:
                        if (WallID.Sets.Conversion.Grass[wall] && wall != ModContent.WallType<Walls.ContagionGrassWall>())
                        {
                            Main.tile[k, l].WallType = (ushort)ModContent.WallType<Walls.ContagionGrassWall>();
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Stone[wall] && wall != ModContent.WallType<Walls.ContagionNaturalWall1>())
                        {
                            Main.tile[k, l].WallType = (ushort)ModContent.WallType<Walls.ContagionNaturalWall1>();
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.HardenedSand[wall] && wall != ModContent.WallType<Walls.ContagionNaturalWall1>())
                        {
                            Main.tile[k, l].WallType = (ushort)ModContent.WallType<Walls.ContagionNaturalWall1>();
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Sandstone[wall] && wall != ModContent.WallType<Walls.ContagionNaturalWall2>())
                        {
                            Main.tile[k, l].WallType = (ushort)ModContent.WallType<Walls.ContagionNaturalWall2>();
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        if ((Main.tileMoss[type] || TileID.Sets.Conversion.Stone[type]) && type != ModContent.TileType<Chunkstone>())
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<Chunkstone>();
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Grass[type] && type != ModContent.TileType<Ickgrass>())
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<Ickgrass>();
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Ice[type] && type != (ushort)ModContent.TileType<YellowIce>())
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<YellowIce>();
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sand[type] && type != ModContent.TileType<Snotsand>())
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<Snotsand>();
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.HardenedSand[type] && type != ModContent.TileType<HardenedSnotsand>())
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<HardenedSnotsand>();
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sandstone[type] && type != ModContent.TileType<Snotsandstone>())
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<Snotsandstone>();
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        continue;
                    #endregion contagion
                    #region tropics (7)
                    case 7:
                        if (WallID.Sets.Conversion.Grass[wall] && wall != ModContent.WallType<Walls.TropicalGrassWall>())
                        {
                            Main.tile[k, l].WallType = (ushort)ModContent.WallType<Walls.TropicalGrassWall>();
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Stone[wall] && wall != ModContent.WallType<Walls.TropicalMudWall>())
                        {
                            Main.tile[k, l].WallType = (ushort)ModContent.WallType<Walls.TropicalMudWall>();
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.HardenedSand[wall] && wall != ModContent.WallType<Walls.TropicalMudWall>())
                        {
                            Main.tile[k, l].WallType = (ushort)ModContent.WallType<Walls.TropicalMudWall>();
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (WallID.Sets.Conversion.Sandstone[wall] && wall != ModContent.WallType<Walls.TropicalMudWall>())
                        {
                            Main.tile[k, l].WallType = (ushort)ModContent.WallType<Walls.TropicalMudWall>();
                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        if ((Main.tileMoss[type] || TileID.Sets.Conversion.Stone[type]) && type != TileID.Stone)
                        {
                            Main.tile[k, l].TileType = TileID.Stone;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (type == 0 || type == 59)
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<TropicalMud>();
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Grass[type] && type != ModContent.TileType<TropicalGrass>())
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<TropicalGrass>();
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Ice[type] && type != (ushort)ModContent.TileType<BrownIce>())
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<BrownIce>();
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sand[type] && type != TileID.Sand)
                        {
                            Main.tile[k, l].TileType = TileID.Sand;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.HardenedSand[type] && type != TileID.HardenedSand)
                        {
                            Main.tile[k, l].TileType = TileID.HardenedSand;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (TileID.Sets.Conversion.Sandstone[type] && type != TileID.Sandstone)
                        {
                            Main.tile[k, l].TileType = TileID.Sandstone;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        continue;
                    #endregion tropics
                }
                if (Main.tile[k, l].WallType == 69 || Main.tile[k, l].WallType == 70 || Main.tile[k, l].WallType == 81)
                {
                    if ((double)l < Main.worldSurface)
                    {
                        if (WorldGen.genRand.Next(10) == 0)
                        {
                            Main.tile[k, l].WallType = 65;
                        }
                        else
                        {
                            Main.tile[k, l].WallType = 63;
                        }
                    }
                    else
                    {
                        Main.tile[k, l].WallType = 64;
                    }
                    WorldGen.SquareWallFrame(k, l);
                    NetMessage.SendTileSquare(-1, k, l, 1);
                }
                else if (Main.tile[k, l].WallType == 3 || Main.tile[k, l].WallType == 28 || Main.tile[k, l].WallType == 83)
                {
                    Main.tile[k, l].WallType = 1;
                    WorldGen.SquareWallFrame(k, l);
                    NetMessage.SendTileSquare(-1, k, l, 1);
                }
                else if (Main.tile[k, l].WallType == 80)
                {
                    if ((double)l < Main.worldSurface + 4.0 + (double)WorldGen.genRand.Next(3) || (double)l > ((double)Main.maxTilesY + Main.rockLayer) / 2.0 - 3.0 + (double)WorldGen.genRand.Next(3))
                    {
                        Main.tile[k, l].WallType = 15;
                        WorldGen.SquareWallFrame(k, l);
                        NetMessage.SendTileSquare(-1, k, l, 3);
                    }
                    else
                    {
                        Main.tile[k, l].WallType = 64;
                        WorldGen.SquareWallFrame(k, l);
                        NetMessage.SendTileSquare(-1, k, l, 3);
                    }
                }
                else if (WallID.Sets.Conversion.HardenedSand[wall] && wall != 216)
                {
                    Main.tile[k, l].WallType = 216;
                    WorldGen.SquareWallFrame(k, l);
                    NetMessage.SendTileSquare(-1, k, l, 1);
                }
                else if (WallID.Sets.Conversion.Sandstone[wall] && wall != 187)
                {
                    Main.tile[k, l].WallType = 187;
                    WorldGen.SquareWallFrame(k, l);
                    NetMessage.SendTileSquare(-1, k, l, 1);
                }
                if (Main.tile[k, l].TileType == 23 || Main.tile[k, l].TileType == 109 || Main.tile[k, l].TileType == 199)
                {
                    Main.tile[k, l].TileType = 2;
                    WorldGen.SquareTileFrame(k, l);
                    NetMessage.SendTileSquare(-1, k, l, 1);
                }
                else if (Main.tile[k, l].TileType == 117 || Main.tile[k, l].TileType == 25 || Main.tile[k, l].TileType == 203)
                {
                    Main.tile[k, l].TileType = 1;
                    WorldGen.SquareTileFrame(k, l);
                    NetMessage.SendTileSquare(-1, k, l, 1);
                }
                else if (Main.tile[k, l].TileType == 112 || Main.tile[k, l].TileType == 116 || Main.tile[k, l].TileType == 234)
                {
                    Main.tile[k, l].TileType = 53;
                    WorldGen.SquareTileFrame(k, l);
                    NetMessage.SendTileSquare(-1, k, l, 1);
                }
                else if (Main.tile[k, l].TileType == 398 || Main.tile[k, l].TileType == 402 || Main.tile[k, l].TileType == 399)
                {
                    Main.tile[k, l].TileType = 397;
                    WorldGen.SquareTileFrame(k, l);
                    NetMessage.SendTileSquare(-1, k, l, 1);
                }
                else if (Main.tile[k, l].TileType == 400 || Main.tile[k, l].TileType == 403 || Main.tile[k, l].TileType == 401)
                {
                    Main.tile[k, l].TileType = 396;
                    WorldGen.SquareTileFrame(k, l);
                    NetMessage.SendTileSquare(-1, k, l, 1);
                }
                else if (Main.tile[k, l].TileType == 164 || Main.tile[k, l].TileType == 163 || Main.tile[k, l].TileType == 200)
                {
                    Main.tile[k, l].TileType = 161;
                    WorldGen.SquareTileFrame(k, l);
                    NetMessage.SendTileSquare(-1, k, l, 1);
                }
                else if (Main.tile[k, l].TileType == 70)
                {
                    Main.tile[k, l].TileType = 60;
                    WorldGen.SquareTileFrame(k, l);
                    NetMessage.SendTileSquare(-1, k, l, 1);
                }
                else if (Main.tile[k, l].TileType == 32 || Main.tile[k, l].TileType == 352)
                {
                    WorldGen.KillTile(k, l);
                    if (Main.netMode == 1)
                    {
                        NetMessage.SendData(17, -1, -1, null, 0, k, l);
                    }
                }
            }
        }
    }

    public static void ConvertFromThings(int x, int y, int convert, bool tileframe = true)
    {
        Tile tile = Main.tile[x, y];
        int type = tile.TileType;
        int wall = tile.WallType;
        if (!WorldGen.InWorld(x, y, 1))
        {
            return;
        }
        if (convert == 0)
        {
            if (Main.tile[x, y] != null)
            {
                if (wall == ModContent.WallType<Walls.ContagionGrassWall>())
                {
                    Main.tile[x, y].WallType = WallID.GrassUnsafe;
                }
                else if (wall == ModContent.WallType<Walls.ChunkstoneWall>())
                {
                    Main.tile[x, y].WallType = WallID.Stone;
                }
            }
            if (Main.tile[x, y] != null)
            {
                if (type == ModContent.TileType<Ickgrass>())
                {
                    tile.TileType = TileID.Grass;
                }
                else if (type == ModContent.TileType<YellowIce>())
                {
                    tile.TileType = TileID.IceBlock;
                }
                else if (type == ModContent.TileType<Snotsand>())
                {
                    tile.TileType = TileID.Sand;
                }
                else if (type == ModContent.TileType<Chunkstone>())
                {
                    tile.TileType = TileID.Stone;
                }
                else if (type == ModContent.TileType<Snotsandstone>())
                {
                    tile.TileType = TileID.Sandstone;
                }
                else if (type == ModContent.TileType<HardenedSnotsand>())
                {
                    tile.TileType = TileID.HardenedSand;
                }
                //else if (type == ModContent.TileType<ContagionShortGrass>())
                //{
                //    tile.type = TileID.Plants;
                //}
                if (TileID.Sets.Conversion.Grass[type] || type == 0)
                {
                    WorldGen.SquareTileFrame(x, y);
                }
            }
        }
        if (convert == 1)
        {
            if (Main.tile[x, y] != null)
            {
                if (wall == ModContent.WallType<Walls.ContagionGrassWall>() || wall == WallID.CrimsonGrassUnsafe || wall == WallID.CorruptGrassUnsafe || wall == WallID.HallowedGrassUnsafe)
                {
                    Main.tile[x, y].WallType = WallID.JungleUnsafe;
                }
                else if (wall == WallID.DirtUnsafe)
                {
                    Main.tile[x, y].WallType = WallID.MudUnsafe;
                }
            }
            if (Main.tile[x, y] != null)
            {
                if (type == ModContent.TileType<Ickgrass>() || type == TileID.CrimsonGrass || type == TileID.CorruptGrass || type == TileID.Grass || type == TileID.HallowedGrass)
                {
                    tile.TileType = TileID.JungleGrass;
                }
                else if (type == TileID.Dirt)
                {
                    tile.TileType = TileID.Mud;
                }
                else if (type == ModContent.TileType<Snotsand>() || type == TileID.Sand || type == TileID.Crimsand || type == TileID.Ebonsand || type == TileID.Pearlsand)
                {
                    tile.TileType = TileID.Sand;
                }
                else if (type == ModContent.TileType<Chunkstone>() || type == TileID.Pearlstone || type == TileID.Crimstone || type == TileID.Ebonstone)
                {
                    tile.TileType = TileID.Stone;
                }
                else if (type == ModContent.TileType<Snotsandstone>() || type == TileID.HallowSandstone || type == TileID.CrimsonSandstone || type == TileID.CorruptSandstone)
                {
                    tile.TileType = TileID.Sandstone;
                }
                else if (type == ModContent.TileType<HardenedSnotsand>() || type == TileID.HallowHardenedSand || type == TileID.CrimsonHardenedSand || type == TileID.CorruptHardenedSand)
                {
                    tile.TileType = TileID.HardenedSand;
                }
                else if (type == ModContent.TileType<YellowIce>() || type == TileID.HallowedIce || type == TileID.FleshIce || type == TileID.CorruptIce || type == TileID.IceBlock)
                {
                    tile.TileType = (ushort)ModContent.TileType<GreenIce>();
                }
                if (TileID.Sets.Conversion.Grass[type] || type == 0)
                {
                    WorldGen.SquareTileFrame(x, y);
                }
            }
        }
        if (convert == 2 && WorldDarkMatterTiles < 250000)
        {
            if (Main.tile[x, y] != null)
            {
                if (wall == WallID.JungleUnsafe || wall == WallID.GrassUnsafe || wall == ModContent.WallType<Walls.ContagionGrassWall>() || wall == WallID.CrimsonGrassUnsafe || wall == WallID.CorruptGrassUnsafe || wall == WallID.HallowedGrassUnsafe)
                {
                    Main.tile[x, y].WallType = (ushort)ModContent.WallType<Walls.DarkMatterGrassWall>();
                }
                else if (wall == WallID.DirtUnsafe)
                {
                    Main.tile[x, y].WallType = (ushort)ModContent.WallType<Walls.DarkMatterSoilWall>();
                }
                else if (WallID.Sets.Conversion.Stone[wall])
                {
                    Main.tile[x, y].WallType = (ushort)ModContent.WallType<Walls.DarkMatterStoneWall>();
                }
            }
            if (Main.tile[x, y] != null)
            {
                if (type == ModContent.TileType<Ickgrass>() || type == ModContent.TileType<TropicalGrass>() || type == TileID.JungleGrass || type == TileID.MushroomGrass || type == TileID.CrimsonGrass || type == TileID.CorruptGrass || type == TileID.Grass || type == TileID.HallowedGrass)
                {
                    tile.TileType = (ushort)ModContent.TileType<DarkMatterGrass>();
                }
                else if (type == TileID.Dirt || type == TileID.ClayBlock || type == TileID.Mud || type == ModContent.TileType<TropicalMud>())
                {
                    tile.TileType = (ushort)ModContent.TileType<DarkMatterSoil>();
                }
                else if (type == ModContent.TileType<Snotsand>() || type == TileID.Sand || type == TileID.Crimsand || type == TileID.Ebonsand || type == TileID.Pearlsand)
                {
                    tile.TileType = (ushort)ModContent.TileType<DarkMatterSand>();
                }
                else if (type == ModContent.TileType<Chunkstone>() || type == TileID.Stone || type == TileID.Pearlstone || type == TileID.Crimstone || type == TileID.Ebonstone)
                {
                    tile.TileType = (ushort)ModContent.TileType<DarkMatter>();
                }
                else if (type == ModContent.TileType<Snotsandstone>() || type == TileID.Sandstone || type == TileID.HallowSandstone || type == TileID.CrimsonSandstone || type == TileID.CorruptSandstone)
                {
                    tile.TileType = (ushort)ModContent.TileType<Darksandstone>();
                }
                else if (type == ModContent.TileType<HardenedSnotsand>() || type == TileID.HardenedSand || type == TileID.HallowHardenedSand || type == TileID.CrimsonHardenedSand || type == TileID.CorruptHardenedSand)
                {
                    tile.TileType = (ushort)ModContent.TileType<HardenedDarkSand>();
                }
                else if (type == ModContent.TileType<YellowIce>() || type == TileID.HallowedIce || type == TileID.FleshIce || type == TileID.CorruptIce || type == TileID.IceBlock || type == ModContent.TileType<GreenIce>() || type == ModContent.TileType<BrownIce>())
                {
                    tile.TileType = (ushort)ModContent.TileType<BlackIce>();
                }
                if (TileID.Sets.Conversion.Grass[type] || type == 0)
                {
                    WorldGen.SquareTileFrame(x, y);
                }
            }
        }
        if (tileframe)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                WorldGen.SquareTileFrame(x, y);
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendTileSquare(-1, x, y, 1);
            }
        }
    }

    public override void ModifyHardmodeTasks(List<GenPass> list)
    {
        int index = list.FindIndex(genpass => genpass.Name.Equals("Hardmode Good"));
        int index2 = list.FindIndex(genpass => genpass.Name.Equals("Hardmode Evil"));
        int index3 = list.FindIndex(genpass => genpass.Name.Equals(""));
        if (contagion)
        {
            list.Insert(index + 1, new PassLegacy("Exxo Avalon Origins: Hardmode Contagion", new WorldGenLegacyMethod(World.Passes.ContagionHardMode.Method)));
            // TODO REPLACE EVIL GEN INSTEAD OF REMOVING
            list.RemoveAt(index);
            list.RemoveAt(index2);
        }
        else
        {
            list.Insert(index + 1, new PassLegacy("Exxo Avalon Origins: Hardmode Good (Hallowed Altars)", new WorldGenLegacyMethod(World.Passes.HallowedAltars.Method)));
            list.RemoveAt(index);
        }
        list.Insert(index + 2, new PassLegacy("Hardmode snow ore generation", new WorldGenLegacyMethod(World.Passes.SnowHardMode.Method)));

    }

    public override void NetSend(BinaryWriter writer)
    {
        var flags = new BitsByte();
        flags[0] = SuperHardmode;
        flags[1] = downedPhantasm;
        flags[2] = contagion;
        flags[3] = downedBacteriumPrime;
        flags[4] = downedDesertBeak;
        flags[5] = downedDragonLord;
        flags[6] = downedMechasting;
        flags[7] = oblivionDead;
        writer.Write(flags);
        writer.WriteVector2(LoK);
        writer.Write(shmOreTier1);
        writer.Write(shmOreTier2);
        writer.Write(hallowAltarCount);
        writer.Write(ExxoAvalonOriginsWorld.stoppedArmageddon);
        writer.Write(specialWireHitCount);
    }

    public override void NetReceive(BinaryReader reader)
    {
        BitsByte flags = reader.ReadByte();
        SuperHardmode = flags[0];
        downedBacteriumPrime = flags[3];
        downedDesertBeak = flags[4];
        downedPhantasm = flags[1];
        downedDragonLord = flags[5];
        downedMechasting = flags[6];
        oblivionDead = flags[7];
        contagion = flags[2];
        LoK = reader.ReadVector2();
        shmOreTier1 = reader.ReadInt32();
        shmOreTier2 = reader.ReadInt32();
        hallowAltarCount = reader.ReadInt32();
        ExxoAvalonOriginsWorld.stoppedArmageddon = reader.ReadBoolean();
        specialWireHitCount = reader.ReadInt32();
    }

    public static void GenerateSulphur()
    {
        if (Main.rand == null)
        {
            Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
        }
        for (int a = 0; a < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); a++)
        {
            int x = Main.rand.Next(100, Main.maxTilesX - 100);
            int y = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 150);
            WorldGen.OreRunner(x, y, Main.rand.Next(7, 9), Main.rand.Next(5, 7), (ushort)ModContent.TileType<Tiles.Ores.SulphurOre>());
        }
        if (Main.netMode == NetmodeID.SinglePlayer)
        {
            Main.NewText("The underground smells like rotten eggs...", 210, 183, 4);
        }
        else if (Main.netMode == NetmodeID.Server)
        {
            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The underground smells like rotten eggs..."), new Color(210, 183, 4));
        }
    }

    public static void GrowLargeHerb(int x, int y)
    {
        if (Main.tile[x, y].HasTile)
        {
            if (Main.tile[x, y].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage1>() && WorldGen.genRand.Next(8) == 0) // phase 1 to 2
            {
                bool grow = false;
                if (Main.tile[x, y].TileFrameX == 108) // shiverthorn check
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        grow = true;
                    }
                }
                else
                {
                    grow = true;
                }
                if (grow)
                {
                    Main.tile[x, y].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>();
                    if (Main.tile[x, y + 1].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage1>())
                    {
                        Main.tile[x, y + 1].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>();
                    }

                    if (Main.tile[x, y + 2].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage1>())
                    {
                        Main.tile[x, y + 2].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>();
                    }

                    if (Main.tile[x, y - 1].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage1>())
                    {
                        Main.tile[x, y - 1].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>();
                    }

                    if (Main.tile[x, y - 2].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage1>())
                    {
                        Main.tile[x, y - 2].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>();
                    }

                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendTileSquare(-1, x, y, 2);
                        NetMessage.SendTileSquare(-1, x, y + 1, 2);
                        NetMessage.SendTileSquare(-1, x, y + 2, 2);
                        NetMessage.SendTileSquare(-1, x, y - 1, 2);
                        NetMessage.SendTileSquare(-1, x, y - 2, 2);
                    }
                    World.Utils.SquareTileFrameArea(x, y, 4, true);
                    return;
                }
            }
            else if (Main.tile[x, y].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>() && WorldGen.genRand.Next(7) == 0) // phase 2 to 3
            {
                bool grow = false;
                if (Main.tile[x, y].TileFrameX == 108) // shiverthorn check
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        grow = true;
                    }
                }
                else
                {
                    grow = true;
                }
                if (grow)
                {
                    Main.tile[x, y].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>();
                    if (Main.tile[x, y + 1].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>())
                    {
                        Main.tile[x, y + 1].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>();
                    }

                    if (Main.tile[x, y + 2].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>())
                    {
                        Main.tile[x, y + 2].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>();
                    }

                    if (Main.tile[x, y - 1].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>())
                    {
                        Main.tile[x, y - 1].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>();
                    }

                    if (Main.tile[x, y - 2].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>())
                    {
                        Main.tile[x, y - 2].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>();
                    }

                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendTileSquare(-1, x, y, 2);
                        NetMessage.SendTileSquare(-1, x, y + 1, 2);
                        NetMessage.SendTileSquare(-1, x, y + 2, 2);
                        NetMessage.SendTileSquare(-1, x, y - 1, 2);
                        NetMessage.SendTileSquare(-1, x, y - 2, 2);
                    }
                    World.Utils.SquareTileFrameArea(x, y, 4, true);
                    return;
                }
            }
            else if (Main.tile[x, y].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>() && WorldGen.genRand.Next(5) == 0) // phase 3 to 4
            {
                Main.tile[x, y].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage4>();
                if (Main.tile[x, y + 1].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>())
                {
                    Main.tile[x, y + 1].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage4>();
                }

                if (Main.tile[x, y + 2].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>())
                {
                    Main.tile[x, y + 2].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage4>();
                }

                if (Main.tile[x, y - 1].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>())
                {
                    Main.tile[x, y - 1].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage4>();
                }

                if (Main.tile[x, y - 2].TileType == (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>())
                {
                    Main.tile[x, y - 2].TileType = (ushort)ModContent.TileType<Tiles.LargeHerbsStage4>();
                }

                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendTileSquare(-1, x, y, 2);
                    NetMessage.SendTileSquare(-1, x, y + 1, 2);
                    NetMessage.SendTileSquare(-1, x, y + 2, 2);
                    NetMessage.SendTileSquare(-1, x, y - 1, 2);
                    NetMessage.SendTileSquare(-1, x, y - 2, 2);
                }
                World.Utils.SquareTileFrameArea(x, y, 4, true);
                return;
            }
        }
    }
    public void DarkMatterSpread(int i, int j)
    {
        if (!Main.hardMode || Main.tile[i, j].IsActuated)
        {
            return;
        }

        int type = Main.tile[i, j].TileType;
        int wall = Main.tile[i, j].WallType;
        if (SuperHardmode)
        {
            if (type == ModContent.TileType<DarkMatter>() || type == ModContent.TileType<DarkMatterSoil>() || type == ModContent.TileType<DarkMatterGrass>() || type == ModContent.TileType<DarkMatterSand>() || type == ModContent.TileType<HardenedDarkSand>() || type == ModContent.TileType<Darksandstone>() || type == ModContent.TileType<BlackIce>())
            {
                bool flag5 = true;
                while (flag5)
                {
                    flag5 = false;
                    int num6 = i + WorldGen.genRand.Next(-3, 4);
                    int num7 = j + WorldGen.genRand.Next(-3, 4);
                    if (Main.tile[num6, num7 - 1].TileType == 27)
                    {
                        continue;
                    }
                    if (Main.tile[num6, num7].TileType == TileID.Grass || Main.tile[num6, num7].TileType == TileID.JungleGrass ||
                        Main.tile[num6, num7].TileType == TileID.MushroomGrass || Main.tile[num6, num7].TileType == TileID.CorruptGrass ||
                        Main.tile[num6, num7].TileType == TileID.CrimsonGrass || Main.tile[num6, num7].TileType == TileID.HallowedGrass ||
                        Main.tile[num6, num7].TileType == (ushort)ModContent.TileType<Ickgrass>() ||
                        Main.tile[num6, num7].TileType == (ushort)ModContent.TileType<TropicalGrass>())
                    {
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            flag5 = true;
                        }
                        Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<DarkMatterGrass>();
                        WorldGen.SquareTileFrame(num6, num7);
                        NetMessage.SendTileSquare(-1, num6, num7, 1);
                    }
                    if (Main.tile[num6, num7].TileType == TileID.Dirt || Main.tile[num6, num7].TileType == TileID.Mud ||
                        Main.tile[num6, num7].TileType == TileID.ClayBlock ||
                        Main.tile[num6, num7].TileType == (ushort)ModContent.TileType<TropicalMud>())
                    {
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            flag5 = true;
                        }
                        Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<DarkMatterSoil>();
                        WorldGen.SquareTileFrame(num6, num7);
                        NetMessage.SendTileSquare(-1, num6, num7, 1);
                    }
                    else if (Main.tile[num6, num7].TileType == TileID.Stone || Main.tile[num6, num7].TileType == TileID.Crimstone ||
                             Main.tile[num6, num7].TileType == TileID.Ebonstone || Main.tile[num6, num7].TileType == TileID.Pearlstone ||
                             Main.tile[num6, num7].TileType == (ushort)ModContent.TileType<Chunkstone>() || Main.tileMoss[Main.tile[num6, num7].TileType])
                    {
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            flag5 = true;
                        }
                        Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<DarkMatter>();
                        WorldGen.SquareTileFrame(num6, num7);
                        NetMessage.SendTileSquare(-1, num6, num7, 1);
                    }
                    else if (Main.tile[num6, num7].TileType == TileID.Sand || Main.tile[num6, num7].TileType == TileID.Pearlsand ||
                             Main.tile[num6, num7].TileType == TileID.Ebonsand || Main.tile[num6, num7].TileType == TileID.Crimsand ||
                             Main.tile[num6, num7].TileType == (ushort)ModContent.TileType<Snotsand>())
                    {
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            flag5 = true;
                        }
                        Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<DarkMatterSand>();
                        WorldGen.SquareTileFrame(num6, num7);
                        NetMessage.SendTileSquare(-1, num6, num7, 1);
                    }
                    else if (Main.tile[num6, num7].TileType == TileID.Sandstone || Main.tile[num6, num7].TileType == TileID.CrimsonSandstone ||
                             Main.tile[num6, num7].TileType == TileID.CorruptSandstone || Main.tile[num6, num7].TileType == TileID.HallowSandstone ||
                             Main.tile[num6, num7].TileType == (ushort)ModContent.TileType<Snotsandstone>())
                    {
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            flag5 = true;
                        }
                        Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<Darksandstone>();
                        WorldGen.SquareTileFrame(num6, num7);
                        NetMessage.SendTileSquare(-1, num6, num7, 1);
                    }
                    else if (Main.tile[num6, num7].TileType == TileID.HardenedSand || Main.tile[num6, num7].TileType == TileID.CrimsonHardenedSand ||
                             Main.tile[num6, num7].TileType == TileID.CorruptHardenedSand || Main.tile[num6, num7].TileType == TileID.HallowHardenedSand ||
                             Main.tile[num6, num7].TileType == (ushort)ModContent.TileType<HardenedSnotsand>())
                    {
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            flag5 = true;
                        }
                        Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<HardenedDarkSand>();
                        WorldGen.SquareTileFrame(num6, num7);
                        NetMessage.SendTileSquare(-1, num6, num7, 1);
                    }
                    else if (Main.tile[num6, num7].TileType == TileID.IceBlock || Main.tile[num6, num7].TileType == TileID.FleshIce ||
                             Main.tile[num6, num7].TileType == TileID.CorruptIce || Main.tile[num6, num7].TileType == TileID.HallowedIce ||
                             Main.tile[num6, num7].TileType == (ushort)ModContent.TileType<YellowIce>() ||
                             Main.tile[num6, num7].TileType == (ushort)ModContent.TileType<GreenIce>() ||
                             Main.tile[num6, num7].TileType == (ushort)ModContent.TileType<BrownIce>())
                    {
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            flag5 = true;
                        }
                        Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<BlackIce>();
                        WorldGen.SquareTileFrame(num6, num7);
                        NetMessage.SendTileSquare(-1, num6, num7, 1);
                    }
                }
            }
        }
    }

    public static void ContagionHardmodeSpread(int i, int j)
    {
        if (!Main.hardMode || Main.tile[i, j].IsActuated)
        {
            return;
        }
        int type = Main.tile[i, j].TileType;
        if (type == ModContent.TileType<Tiles.Chunkstone>() || type == ModContent.TileType<Ickgrass>() || type == ModContent.TileType<Snotsand>() || type == ModContent.TileType<HardenedSnotsand>() || type == ModContent.TileType<Snotsandstone>() || type == ModContent.TileType<YellowIce>())
        {
            bool flag5 = true;
            while (flag5)
            {
                flag5 = false;
                int num6 = i + WorldGen.genRand.Next(-3, 4);
                int num7 = j + WorldGen.genRand.Next(-3, 4);
                //bool flag6 = NearbyChlorophyte(num6, num7);
                if (Main.tile[num6, num7 - 1].TileType == 27)
                {
                    continue;
                }
                if (Main.tile[num6, num7].TileType == 2)
                {
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        flag5 = true;
                    }
                    Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<Ickgrass>();
                    WorldGen.SquareTileFrame(num6, num7);
                    NetMessage.SendTileSquare(-1, num6, num7, 1);
                }
                else if (Main.tile[num6, num7].TileType == 1 || Main.tileMoss[Main.tile[num6, num7].TileType])
                {
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        flag5 = true;
                    }
                    Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<Chunkstone>();
                    WorldGen.SquareTileFrame(num6, num7);
                    NetMessage.SendTileSquare(-1, num6, num7, 1);
                }
                else if (Main.tile[num6, num7].TileType == 53)
                {
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        flag5 = true;
                    }
                    Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<Snotsand>();
                    WorldGen.SquareTileFrame(num6, num7);
                    NetMessage.SendTileSquare(-1, num6, num7, 1);
                }
                else if (Main.tile[num6, num7].TileType == 396)
                {
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        flag5 = true;
                    }
                    Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<Snotsandstone>();
                    WorldGen.SquareTileFrame(num6, num7);
                    NetMessage.SendTileSquare(-1, num6, num7, 1);
                }
                else if (Main.tile[num6, num7].TileType == 397)
                {
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        flag5 = true;
                    }
                    Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<HardenedSnotsand>();
                    WorldGen.SquareTileFrame(num6, num7);
                    NetMessage.SendTileSquare(-1, num6, num7, 1);
                }
                else if (Main.tile[num6, num7].TileType == 161)
                {
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        flag5 = true;
                    }
                    Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<YellowIce>();
                    WorldGen.SquareTileFrame(num6, num7);
                    NetMessage.SendTileSquare(-1, num6, num7, 1);
                }
            }
        }
    }
    public override void PostUpdateWorld()
    {
        float num2 = 3E-05f * (float)WorldGen.GetWorldUpdateRate();
        //float num3 = 1.5E-05f * (float)Main.worldRate;
        int num4 = 0;
        while (num4 < Main.maxTilesX * Main.maxTilesY * num2)
        {
            int num5 = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
            int num6 = WorldGen.genRand.Next(10, /*(int)Main.worldSurface - 1*/ Main.maxTilesY - 20);
            int num7 = num5 - 1;
            int num8 = num5 + 2;
            int num9 = num6 - 1;
            int num10 = num6 + 2;
            if (num7 < 10)
            {
                num7 = 10;
            }
            if (num8 > Main.maxTilesX - 10)
            {
                num8 = Main.maxTilesX - 10;
            }
            if (num9 < 10)
            {
                num9 = 10;
            }
            if (num10 > Main.maxTilesY - 10)
            {
                num10 = Main.maxTilesY - 10;
            }
            if (Main.tile[num5, num6] != null)
            {
                if (Main.tile[num5, num6].TileType == (ushort)ModContent.TileType<LargeHerbsStage1>() || Main.tile[num5, num6].TileType == (ushort)ModContent.TileType<LargeHerbsStage2>() ||
                    Main.tile[num5, num6].TileType == (ushort)ModContent.TileType<LargeHerbsStage3>())
                {
                    GrowLargeHerb(num5, num6);
                }

                #region hardmode/superhardmode stuff
                if (Main.tile[num5, num6].HasUnactuatedTile)
                {
                    ContagionHardmodeSpread(num5, num6);
                    if (Main.hardMode)
                    {
                        SpreadXanthophyte(num5, num6);
                    }

                    if (SuperHardmode && WorldDarkMatterTiles < 250000)
                    {
                        DarkMatterSpread(num5, num6);
                    }
                }
                #endregion hardmode/superhardmode stuff

                #region crystal shard in crystal mines
                if (SuperHardmode)
                {
                    int type = (int)Main.tile[num5, num6].TileType;
                    if ((type == ModContent.TileType<CrystalStone>()) && num6 > Main.rockLayer && Main.rand.Next(65) == 0)
                    {
                        int num = WorldGen.genRand.Next(4);
                        int xdir = 0;
                        int ydir = 0;
                        if (num == 0)
                        {
                            xdir = -1;
                        }
                        else if (num == 1)
                        {
                            xdir = 1;
                        }
                        else if (num == 0)
                        {
                            ydir = -1;
                        }
                        else
                        {
                            ydir = 1;
                        }
                        if (!Main.tile[num5 + xdir, num6 + ydir].HasTile)
                        {
                            int q = 0;
                            int z = 6;
                            for (int k = num5 - z; k <= num5 + z; k++)
                            {
                                for (int l = num6 - z; l <= num6 + z; l++)
                                {
                                    if (Main.tile[k, l].HasTile && Main.tile[k, l].TileType == TileID.Crystals)
                                    {
                                        q++;
                                    }
                                }
                            }
                            if (q < 2)
                            {
                                if (ydir != -1)
                                {
                                    WorldGen.PlaceTile(num5 + xdir, num6 + ydir, TileID.Crystals, true, false, -1, 0);
                                    NetMessage.SendTileSquare(-1, num5 + xdir, num6 + ydir, 1);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region crystal fruit and giant crystal spawning
                if (Main.tile[num5, num6].TileType == ModContent.TileType<CrystalStone>() && SuperHardmode && oblivionDead && num6 > Main.rockLayer)
                {
                    if (WorldGen.genRand.Next(50) == 0 && Main.tile[num5, num9].LiquidAmount == 0)
                    {
                        bool flag16 = true;
                        int distanceCheck = 40;
                        for (int num80 = num5 - distanceCheck; num80 < num5 + distanceCheck; num80 += 2)
                        {
                            for (int num81 = num6 - distanceCheck; num81 < num6 + distanceCheck; num81 += 2)
                            {
                                if (num80 > 1 && num80 < Main.maxTilesX - 2 && num81 > 1 && num81 < Main.maxTilesY - 2 && Main.tile[num80, num81].HasTile && Main.tile[num80, num81].TileType == ModContent.TileType<CrystalFruit>())
                                {
                                    flag16 = false;
                                    break;
                                }
                            }
                        }
                        if (flag16)
                        {
                            WorldGen.Place2x2(num5, num9, (ushort)ModContent.TileType<CrystalFruit>(), WorldGen.genRand.Next(3));
                            WorldGen.SquareTileFrame(num5, num9, true);
                            WorldGen.SquareTileFrame(num5 + 1, num9 + 1, true);
                            if (Main.tile[num5, num9].TileType == ModContent.TileType<CrystalFruit>() && Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendTileSquare(-1, num5, num9, 4);
                            }
                        }
                        else
                        {
                            WorldGen.Place2x2(num5, num9, (ushort)ModContent.TileType<GiantCrystalShard>(), WorldGen.genRand.Next(3));
                            WorldGen.SquareTileFrame(num5, num9, true);
                            WorldGen.SquareTileFrame(num5 + 1, num9 + 1, true);
                            if (Main.tile[num5, num9].TileType == ModContent.TileType<GiantCrystalShard>() && Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendTileSquare(-1, num5, num9, 4);
                            }
                        }
                    }
                }
                #endregion

                #region tropical short grass
                if (Main.tile[num5, num6].TileType == ModContent.TileType<TropicalGrass>())
                {
                    int num14 = Main.tile[num5, num6].TileType;
                    if (!Main.tile[num5, num9].HasTile && !Main.tile[num5, num6].IsHalfBlock && Main.tile[num5, num6].Slope == SlopeType.Solid && WorldGen.genRand.Next(5) == 0 && num14 == ModContent.TileType<TropicalGrass>())
                    {
                        WorldGen.PlaceTile(num5, num9, ModContent.TileType<TropicalShortGrass>(), true, false, -1, 0);
                        Main.tile[num5, num9].TileFrameX = (short)(WorldGen.genRand.Next(0, 8) * 18);
                        if (num9 > Main.worldSurface && WorldGen.genRand.Next(60) == 0)
                        {
                            Main.tile[num5, num9].TileFrameX = 8 * 18;
                            Main.tileLighted[Main.tile[num5, num9].TileType] = true;
                        }
                        if (Main.tile[num5, num9].HasTile)
                        {
                            //Main.tile[num5, num9].color(Main.tile[num5, num6].color());
                        }
                        if (Main.netMode == NetmodeID.Server && Main.tile[num5, num9].HasTile)
                        {
                            NetMessage.SendTileSquare(-1, num5, num9, 1);
                        }
                    }
                    if (!Main.tile[num5, num9].HasUnactuatedTile)
                    {
                        return;
                    }
                    /*if (Main.tile[num5, num9].type == ModContent.TileType<TropicalShortGrass>() && WorldGen.genRand.Next(3) == 0 && Main.tile[num5, num9].frameX < 144)
                    {
                        if (Main.rand.Next(4) == 0)
                        {
                            Main.tile[num5, num9].frameX = (short)(162 + WorldGen.genRand.Next(8) * 18);
                        }
                        Main.tile[num5, num9].type = 74;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendTileSquare(-1, num5, num9, 1);
                        }
                    }*/
                }
                #endregion tropical short grass

                #region holybird spawning

                if (Main.tile[num5, num6].TileType == TileID.HallowedGrass || Main.tile[num5, num6].TileType == TileID.Pearlstone)
                {
                    int num14 = Main.tile[num5, num6].TileType;
                    if (!Main.tile[num5, num9].HasTile && Main.tile[num5, num9].LiquidAmount == 0 && !Main.tile[num5, num6].IsHalfBlock && Main.tile[num5, num6].Slope == SlopeType.Solid && WorldGen.genRand.Next((num6 > Main.worldSurface ? 600 : 250)) == 0 && (num14 == TileID.HallowedGrass || num14 == TileID.Pearlstone))
                    {
                        WorldGen.PlaceTile(num5, num9, ModContent.TileType<Tiles.Herbs.Holybird>(), true, false, -1, 0);
                        if (Main.tile[num5, num9].HasTile)
                        {
                            //Main.tile[num5, num9].color(Main.tile[num5, num6].color());
                        }
                        if (Main.netMode == NetmodeID.Server && Main.tile[num5, num9].HasTile)
                        {
                            NetMessage.SendTileSquare(-1, num5, num9, 1);
                        }
                    }
                }

                #endregion holybird spawning

                #region sweetstem spawning

                if (Main.tile[num5, num6].TileType == ModContent.TileType<Nest>() || Main.tile[num5, num6].TileType == TileID.Hive)
                {
                    int num14 = Main.tile[num5, num6].TileType;
                    if (!Main.tile[num5, num9].HasTile && !Main.tile[num5, num6].IsHalfBlock && Main.tile[num5, num6].Slope == SlopeType.Solid && WorldGen.genRand.Next(450) == 0 && (num14 == ModContent.TileType<Nest>() || num14 == TileID.Hive))
                    {
                        WorldGen.PlaceTile(num5, num9, ModContent.TileType<Tiles.Herbs.Sweetstem>(), true, false, -1, 0);
                        if (Main.tile[num5, num9].HasTile)
                        {
                            //Main.tile[num5, num9].color(Main.tile[num5, num6].color());
                        }
                        if (Main.netMode == NetmodeID.Server && Main.tile[num5, num9].HasTile)
                        {
                            NetMessage.SendTileSquare(-1, num5, num9, 1);
                        }
                    }
                }

                #endregion sweetstem spawning

                #region bloodberry spawning

                if (Main.tile[num5, num6].TileType == TileID.CrimsonGrass || Main.tile[num5, num6].TileType == TileID.Crimstone)
                {
                    int num14 = Main.tile[num5, num6].TileType;
                    if (!Main.tile[num5, num9].HasTile && Main.tile[num5, num9].LiquidAmount == 0 && !Main.tile[num5, num6].IsHalfBlock && Main.tile[num5, num6].Slope == SlopeType.Solid && WorldGen.genRand.Next((num6 > Main.worldSurface ? 500 : 200)) == 0 && (num14 == TileID.CrimsonPlants || num14 == TileID.Crimstone))
                    {
                        WorldGen.PlaceTile(num5, num9, ModContent.TileType<Tiles.Herbs.Bloodberry>(), true, false, -1, 0);
                        if (Main.tile[num5, num9].HasTile)
                        {
                            //Main.tile[num5, num9].color(Main.tile[num5, num6].color());
                        }
                        if (Main.netMode == NetmodeID.Server && Main.tile[num5, num9].HasTile)
                        {
                            NetMessage.SendTileSquare(-1, num5, num9, 1);
                        }
                    }
                }

                #endregion bloodberry spawning

                #region killing things if the block above/below isn't the necessary type
                // kill contagion vines if block above isn't contagion grass
                if (Main.tile[num5, num9].TileType == TileID.Dirt && Main.tile[num5, num6].TileType == ModContent.TileType<ContagionVines>())
                {
                    WorldGen.KillTile(num5, num6);
                }
                // kill contagion short grass if block below isn't contagion grass
                if (Main.tile[num5, num6].TileType == TileID.Dirt && Main.tile[num5, num9].TileType == ModContent.TileType<ContagionShortGrass>())
                {
                    WorldGen.KillTile(num5, num6);
                }
                // kill barfbush if block below isn't contagion grass
                if (Main.tile[num5, num6].TileType == TileID.Dirt && Main.tile[num5, num9].TileType == ModContent.TileType<Tiles.Herbs.Barfbush>())
                {
                    WorldGen.KillTile(num5, num6);
                }
                // kill bloodberry if block below isn't crimson grass
                if (Main.tile[num5, num6].TileType == TileID.Dirt && Main.tile[num5, num9].TileType == ModContent.TileType<Tiles.Herbs.Bloodberry>())
                {
                    WorldGen.KillTile(num5, num6);
                }
                // kill holybird if block below isn't hallowed grass
                if (Main.tile[num5, num6].TileType == TileID.Dirt && Main.tile[num5, num9].TileType == ModContent.TileType<Tiles.Herbs.Holybird>())
                {
                    WorldGen.KillTile(num5, num6);
                }
                #endregion

                #region contagion shortgrass/barfbush spawning

                if (Main.tile[num5, num6].TileType == ModContent.TileType<Ickgrass>())
                {
                    int num14 = Main.tile[num5, num6].TileType;
                    if (!Main.tile[num5, num9].HasTile && Main.tile[num5, num9].LiquidAmount == 0 && !Main.tile[num5, num6].IsHalfBlock && Main.tile[num5, num6].Slope == SlopeType.Solid && WorldGen.genRand.Next(5) == 0 && num14 == ModContent.TileType<Ickgrass>())
                    {
                        WorldGen.PlaceTile(num5, num9, ModContent.TileType<ContagionShortGrass>(), true, false, -1, 0);
                        Main.tile[num5, num9].TileFrameX = (short)(WorldGen.genRand.Next(0, 11) * 18);
                        if (Main.tile[num5, num9].HasTile)
                        {
                            //Main.tile[num5, num9].color(Main.tile[num5, num6].color());
                        }
                        if (Main.netMode == NetmodeID.Server && Main.tile[num5, num9].HasTile)
                        {
                            NetMessage.SendTileSquare(-1, num5, num9, 1);
                        }
                    }
                    if (!Main.tile[num5, num9].HasTile && Main.tile[num5, num9].LiquidAmount == 0 && !Main.tile[num5, num6].IsHalfBlock && Main.tile[num5, num6].Slope == SlopeType.Solid && WorldGen.genRand.Next((num6 > Main.worldSurface ? 500 : 200)) == 0 && num14 == ModContent.TileType<Ickgrass>())
                    {
                        WorldGen.PlaceTile(num5, num9, ModContent.TileType<Tiles.Herbs.Barfbush>(), true, false, -1, 0);
                        if (Main.tile[num5, num9].HasTile)
                        {
                            //Main.tile[num5, num9].color(Main.tile[num5, num6].color());
                        }
                        if (Main.netMode == NetmodeID.Server && Main.tile[num5, num9].HasTile)
                        {
                            NetMessage.SendTileSquare(-1, num5, num9, 1);
                        }
                    }
                    bool flag2 = false;
                    for (int m = num7; m < num8; m++)
                    {
                        for (int n = num9; n < num10; n++)
                        {
                            if ((num5 != m || num6 != n) && Main.tile[m, n].HasTile)
                            {
                                if (Main.tile[m, n].TileType == 0 || (num14 == ModContent.TileType<Ickgrass>() && Main.tile[m, n].TileType == TileID.Grass))
                                {
                                    WorldGen.SpreadGrass(m, n, 0, num14, false, Main.tile[num5, num6].TileColor);
                                    if (num14 == ModContent.TileType<Ickgrass>())
                                    {
                                        WorldGen.SpreadGrass(m, n, TileID.Grass, num14, false, Main.tile[num5, num6].TileColor);
                                    }
                                    if (num14 == ModContent.TileType<Ickgrass>())
                                    {
                                        WorldGen.SpreadGrass(m, n, TileID.HallowedGrass, num14, false, Main.tile[num5, num6].TileColor);
                                    }
                                    if (Main.tile[m, n].TileType == num14)
                                    {
                                        WorldGen.SquareTileFrame(m, n, true);
                                        flag2 = true;
                                    }
                                }
                                if (Main.tile[m, n].TileType == 0 || (num14 == 109 && Main.tile[m, n].TileType == 2) || (num14 == 109 && Main.tile[m, n].TileType == 23) || (num14 == 109 && Main.tile[m, n].TileType == 199))
                                {
                                    if (num14 == TileID.HallowedGrass)
                                    {
                                        WorldGen.SpreadGrass(m, n, ModContent.TileType<Ickgrass>(), num14, false, Main.tile[num5, num6].TileColor);
                                    }
                                }
                            }
                        }
                    }
                    if (Main.netMode == NetmodeID.Server && flag2)
                    {
                        NetMessage.SendTileSquare(-1, num5, num6, 3);
                    }
                }

                #endregion contagion shortgrass/barfbush spawning

                #region lazite grass
                if (Main.tile[num5, num6].TileType == ModContent.TileType<LaziteGrass>())
                {
                    int num14 = Main.tile[num5, num6].TileType;
                    // where lazite tallgrass would grow
                    if (!Main.tile[num5, num9].HasTile && Main.tile[num5, num9].LiquidAmount == 0 && !Main.tile[num5, num6].IsHalfBlock && Main.tile[num5, num6].Slope == SlopeType.Solid && WorldGen.genRand.Next(5) == 0 && num14 == ModContent.TileType<LaziteGrass>())
                    {
                        WorldGen.PlaceTile(num5, num9, ModContent.TileType<LaziteShortGrass>(), true, false, -1, 0);
                        Main.tile[num5, num9].TileFrameX = (short)(WorldGen.genRand.Next(0, 10) * 18);
                        if (Main.tile[num5, num9].HasTile)
                        {
                            //Main.tile[num5, num9].TileColor = (Main.tile[num5, num6].TileColor);
                        }
                        if (Main.netMode == NetmodeID.Server && Main.tile[num5, num9].HasTile)
                        {
                            NetMessage.SendTileSquare(-1, num5, num9, 1);
                        }
                    }
                    bool flag2 = false;
                    for (int m = num7; m < num8; m++)
                    {
                        for (int n = num9; n < num10; n++)
                        {
                            if ((num5 != m || num6 != n) && Main.tile[m, n].HasTile)
                            {
                                if (Main.tile[m, n].TileType == ModContent.TileType<BlackBlaststone>())
                                {
                                    WorldGen.SpreadGrass(m, n, ModContent.TileType<BlackBlaststone>(), ModContent.TileType<LaziteGrass>(), false, Main.tile[num5, num6].TileColor);
                                }
                                if (Main.tile[m, n].TileType == num14)
                                {
                                    WorldGen.SquareTileFrame(m, n, true);
                                    flag2 = true;
                                }
                            }
                        }
                    }
                    if (Main.netMode == NetmodeID.Server && flag2)
                    {
                        NetMessage.SendTileSquare(-1, num5, num6, 3);
                    }
                }
                #endregion

                #region impgrass growing
                if (Main.tile[num5, num6].TileType == ModContent.TileType<Impgrass>())
                {
                    int num14 = Main.tile[num5, num6].TileType;
                    bool flag2 = false;
                    for (int m = num7; m < num8; m++)
                    {
                        for (int n = num9; n < num10; n++)
                        {
                            if ((num5 != m || num6 != n) && Main.tile[m, n].HasTile)
                            {
                                if (Main.tile[m, n].TileType == TileID.Ash)
                                {
                                    WorldGen.SpreadGrass(m, n, TileID.Ash, ModContent.TileType<Impgrass>(), false, Main.tile[num5, num6].TileColor);
                                }
                                if (Main.tile[m, n].TileType == num14)
                                {
                                    WorldGen.SquareTileFrame(m, n, true);
                                    flag2 = true;
                                }
                            }
                        }
                    }
                    if (Main.netMode == NetmodeID.Server && flag2)
                    {
                        NetMessage.SendTileSquare(-1, num5, num6, 3);
                    }
                }
                #endregion

                #region tropical grass growing
                if (Main.tile[num5, num6].TileType == ModContent.TileType<TropicalGrass>())
                {
                    int num14 = Main.tile[num5, num6].TileType;
                    bool flag2 = false;
                    for (int m = num7; m < num8; m++)
                    {
                        for (int n = num9; n < num10; n++)
                        {
                            if ((num5 != m || num6 != n) && Main.tile[m, n].HasTile)
                            {
                                if (Main.tile[m, n].TileType == ModContent.TileType<TropicalMud>())
                                {
                                    WorldGen.SpreadGrass(m, n, ModContent.TileType<TropicalMud>(), ModContent.TileType<TropicalGrass>(), false, Main.tile[num5, num6].TileColor);
                                }
                                if (Main.tile[m, n].TileType == num14)
                                {
                                    WorldGen.SquareTileFrame(m, n, true);
                                    flag2 = true;
                                }
                            }
                        }
                    }
                    if (Main.netMode == NetmodeID.Server && flag2)
                    {
                        NetMessage.SendTileSquare(-1, num5, num6, 3);
                    }
                }
                #endregion

                #region impvines growing

                if ((Main.tile[num5, num6].TileType == ModContent.TileType<Impgrass>() || Main.tile[num5, num6].TileType == ModContent.TileType<Impvines>()) && WorldGen.genRand.Next(15) == 0 && !Main.tile[num5, num6 + 1].HasTile && Main.tile[num5, num6 + 1].LiquidType != LiquidID.Lava)
                {
                    bool flag10 = false;
                    for (int num47 = num6; num47 > num6 - 10; num47--)
                    {
                        if (Main.tile[num5, num47].BottomSlope)
                        {
                            flag10 = false;
                            break;
                        }
                        if (Main.tile[num5, num47].HasTile && Main.tile[num5, num47].TileType == ModContent.TileType<Impgrass>() && !Main.tile[num5, num47].BottomSlope)
                        {
                            flag10 = true;
                            break;
                        }
                    }
                    if (flag10)
                    {
                        int num48 = num5;
                        int num49 = num6 + 1;
                        Main.tile[num48, num49].TileType = (ushort)ModContent.TileType<Impvines>();
                        //Main.tile[num48, num49].active(true);
                        WorldGen.SquareTileFrame(num48, num49, true);
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendTileSquare(-1, num48, num49, 3);
                        }
                    }
                }

                #endregion impvines growing

                #region contagion vines growing

                if ((Main.tile[num5, num6].TileType == ModContent.TileType<Ickgrass>() || Main.tile[num5, num6].TileType == ModContent.TileType<ContagionVines>()) && WorldGen.genRand.Next(15) == 0 && !Main.tile[num5, num6 + 1].HasTile && Main.tile[num5, num6 + 1].LiquidType != LiquidID.Lava)
                {
                    bool flag10 = false;
                    for (int num47 = num6; num47 > num6 - 10; num47--)
                    {
                        if (Main.tile[num5, num47].BottomSlope)
                        {
                            flag10 = false;
                            break;
                        }
                        if (Main.tile[num5, num47].HasTile && Main.tile[num5, num47].TileType == ModContent.TileType<Ickgrass>() && !Main.tile[num5, num47].BottomSlope)
                        {
                            flag10 = true;
                            break;
                        }
                    }
                    if (flag10)
                    {
                        int num48 = num5;
                        int num49 = num6 + 1;
                        Main.tile[num48, num49].TileType = (ushort)ModContent.TileType<ContagionVines>();
                        WorldGen.SquareTileFrame(num48, num49, true);
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendTileSquare(-1, num48, num49, 3);
                        }
                    }
                }

                #endregion contagion vines growing
            }
            num4++;
        }
        if (!Main.dayTime && Main.player[Main.myPlayer].HasBuff(ModContent.BuffType<Buffs.AdvancedBuffs.AdvStarbright>()) || Main.player[Main.myPlayer].HasBuff(ModContent.BuffType<Buffs.Starbright>()))
        {
            float num66 = Main.maxTilesX / 4200;
            if (Main.rand.Next(4000) < 10f * num66)
            {
                int num67 = 12;
                int num68 = Main.rand.Next(Main.maxTilesX - 50) + 100;
                num68 *= 16;
                int num69 = Main.rand.Next((int)(Main.maxTilesY * 0.05));
                num69 *= 16;
                var vector = new Vector2(num68, num69);
                float num70 = Main.rand.Next(-100, 101);
                float num71 = Main.rand.Next(200) + 100;
                float num72 = (float)Math.Sqrt(num70 * num70 + num71 * num71);
                num72 = num67 / num72;
                num70 *= num72;
                num71 *= num72;
                Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_ByProjectileSourceId(ProjectileSourceID.None), vector.X, vector.Y, num70, num71, ProjectileID.FallingStar, 1000, 10f, Main.myPlayer);
            }
        }
        if (!Main.dayTime && Main.player[Main.myPlayer].HasBuff(ModContent.BuffType<Buffs.AdvancedBuffs.AdvStarbright>()))
        {
            float num66 = Main.maxTilesX / 4200;
            if (Main.rand.Next(4000) < 10f * num66)
            {
                int num67 = 12;
                int num68 = Main.rand.Next(Main.maxTilesX - 50) + 100;
                num68 *= 16;
                int num69 = Main.rand.Next((int)(Main.maxTilesY * 0.05));
                num69 *= 16;
                var vector = new Vector2(num68, num69);
                float num70 = Main.rand.Next(-100, 101);
                float num71 = Main.rand.Next(200) + 100;
                float num72 = (float)Math.Sqrt(num70 * num70 + num71 * num71);
                num72 = num67 / num72;
                num70 *= num72;
                num71 *= num72;
                Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_ByProjectileSourceId(ProjectileSourceID.None), vector.X, vector.Y, num70, num71, ProjectileID.FallingStar, 1000, 10f, Main.myPlayer);
            }
        }
        if (!Main.dayTime && Main.bloodMoon)
        {
            float num66 = Main.maxTilesX / 4200;
            if (Main.rand.Next(9000) < 10f * num66)
            {
                int num67 = 12;
                int num68 = Main.rand.Next(Main.maxTilesX - 50) + 100;
                num68 *= 16;
                int num69 = Main.rand.Next((int)(Main.maxTilesY * 0.05));
                num69 *= 16;
                var vector = new Vector2(num68, num69);
                float num70 = Main.rand.Next(-100, 101);
                float num71 = Main.rand.Next(200) + 100;
                float num72 = (float)Math.Sqrt(num70 * num70 + num71 * num71);
                num72 = num67 / num72;
                num70 *= num72;
                num71 *= num72;
                Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_ByProjectileSourceId(ProjectileSourceID.None), vector.X, vector.Y, num70, num71, ProjectileID.FallingStar, 1000, 10f, Main.myPlayer);
            }
        }
        for (int thing = 0; thing < Main.npc.Length; thing++)
        {
            NPC npc1 = Main.npc[thing];
            if ((npc1.type == NPCID.Corruptor || npc1.type == ModContent.NPCType<NPCs.GuardianCorruptor>()) && npc1.active)
            {
                for (int thing2 = 0; thing2 < Main.npc.Length; thing2++)
                {
                    NPC npc2 = Main.npc[thing2];
                    if ((npc2.type == ModContent.NPCType<NPCs.Hallowor>() || npc2.type == ModContent.NPCType<NPCs.AegisHallowor>()) && npc2.active)
                    {
                        int radius;
                        string text;
                        if (npc1.type == NPCID.Corruptor && npc2.type == ModContent.NPCType<NPCs.Hallowor>())
                        {
                            radius = 2;
                            text = "Dark and light have been obliterated...";
                            MakeOblivionOre(npc1, npc2, text, radius);
                        }
                        else if (npc1.type == ModContent.NPCType<NPCs.GuardianCorruptor>() && npc2.type == ModContent.NPCType<NPCs.AegisHallowor>())
                        {
                            radius = 3;
                            text = "Dark and light have been eliminated...";
                            MakeOblivionOre(npc1, npc2, text, radius);
                        }
                    }
                }
            }
        }
    }

    public override void PreUpdateWorld()
    {
        if (!retroGenned)
        {
            if (worldVersion == null || worldVersion < ExxoAvalonOrigins.Mod.Version)
            {
                RetroGen();
                retroGenned = true;
            }
        }
        if (Main.time == 16200.0 && Main.rand.Next(4) == 0 && NPC.downedGolemBoss && ExxoAvalonOriginsWorld.stoppedArmageddon && SuperHardmode && Main.hardMode)
        {
            DropComet(ModContent.TileType<Tiles.Ores.HydrolythOre>());
        }
        Main.tileSolidTop[ModContent.TileType<FallenStarTile>()] = Main.dayTime;
    }

    public override void PreWorldGen()
    {
        SuperHardmode = false;
        stoppedArmageddon = false;
        ExxoAvalonOriginsGlobalNPC.oblivionDead = false;
        ExxoAvalonOriginsGlobalNPC.oblivionTimes = 0;
        downedBacteriumPrime = false;
        downedDesertBeak = false;
        downedDragonLord = false;
        downedMechasting = false;
        oblivionDead = false;
        downedPhantasm = false;
        downedKingSting = false;
        hiddenTemplePos = Vector2.Zero;

        if (jungleMenuSelection == JungleVariant.random)
        {
            jungleMenuSelection = (JungleVariant)WorldGen.genRand.Next(2);
        }

        contagion = false;
        WorldGen.crimson = WorldGen.genRand.Next(2) == 0;
        if (WorldGen.WorldGenParam_Evil == 0)
        {
            WorldGen.crimson = false;
        }
        if (WorldGen.WorldGenParam_Evil == 1)
        {
            WorldGen.crimson = true;
        }
        if (WorldGen.WorldGenParam_Evil == -1)
        {
            contagion = WorldGen.genRand.Next(3) == 0;
            if (contagion)
            {
                WorldGen.crimson = false;
            }
        }
        if (WorldGen.WorldGenParam_Evil == 2)
        {
            contagion = true;
            WorldGen.crimson = false;
        }
    }

    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
    {
        int reset = tasks.FindIndex(genpass => genpass.Name == "Reset");
        if (reset != -1)
        {
            tasks.Insert(reset + 1, new PassLegacy("Avalon Setup", World.Passes.Setup.Method));
        }

        int vines = tasks.FindIndex(genpass => genpass.Name == "Vines");

        if (jungleMenuSelection == JungleVariant.tropics)
        {
            int temple = tasks.FindIndex(genpass => genpass.Name == "Jungle Temple");
            if (temple != -1)
            {
                tasks[temple] = new PassLegacy("Tuhrtl Outpost", World.Passes.TuhrtlOutpost.Method);
                //tasks.RemoveAt(temple);
            }

            int hives = tasks.FindIndex(genpass => genpass.Name == "Hives");
            if (hives != -1)
            {
                tasks[hives] = new PassLegacy("Wasp Nests", World.Passes.WaspNest.Method);
                //tasks.RemoveAt(hives);
            }

            int jchests = tasks.FindIndex(genpass => genpass.Name == "Jungle Chests");
            if (jchests != -1)
            {
                tasks[jchests] = new PassLegacy("Sanctums", World.Passes.TropicsSanctum.Method);
                //tasks.RemoveAt(jchests);
            }

            int jtemple2 = tasks.FindIndex(genpass => genpass.Name == "Temple");
            if (jtemple2 != -1)
            {
                tasks.RemoveAt(jtemple2);
            }

            int jplants = tasks.FindIndex(genpass => genpass.Name == "Jungle Plants");
            if (jplants != -1)
            {
                tasks.RemoveAt(jplants);
            }

            if (vines != -1)
            {
                tasks.Insert(vines + 1, new PassLegacy("TropicalVines", World.Passes.TropicalVines.Method));
            }
        }

        if (vines != -1)
        {
            tasks.Insert(vines + 1, new PassLegacy("Impvines", World.Passes.Impvines.Method));
        }

        if (vines != -1)
        {
            if (contagion)
            {
                tasks.Insert(vines + 1, new PassLegacy("ContagionVines", World.Passes.ContagionVines.Method));
            }
        }

        int shinies = tasks.FindIndex(genpass => genpass.Name == "Shinies");
        if (shinies != -1)
        {
            tasks[shinies] = new PassLegacy("Avalon PHM Ore Gen", World.Passes.OreGenPreHardMode.Method);
        }

        int underworld = tasks.FindIndex(genpass => genpass.Name == "Underworld");
        if (underworld != -1)
        {
            tasks.Insert(underworld + 1, new PassLegacy("Avalon Underworld", World.Passes.Underworld.Method));
        }

        if (contagion)
        {
            int corruptionTask = tasks.FindIndex(genpass => genpass.Name == "Corruption");
            if (corruptionTask != -1)
            {
                // Replace corruption task with contagion task
                tasks[corruptionTask] = new PassLegacy("Corruption", World.Passes.Contagion.Method);
            }

            int altarsTask = tasks.FindIndex(genpass => genpass.Name == "Altars");
            if (altarsTask != -1)
            {
                tasks[altarsTask] = new PassLegacy("Altars", World.Passes.Altars.Method);
            }
        }

        int gems = tasks.FindIndex(genpass => genpass.Name == "Gems");
        if (gems != -1)
        {
            tasks.Insert(gems + 1, new PassLegacy("Avalon Gems", World.Passes.Gems.Method));
        }

        int smoothWorld = tasks.FindIndex(genpass => genpass.Name == "Smooth World");
        if (smoothWorld != -1)
        {
            tasks.Insert(smoothWorld + 1, new PassLegacy("Unsmoothing Hellcastle", World.Passes.SmoothWorld.Method));
        }

        int lifecrystals = tasks.FindIndex(genpass => genpass.Name == "Life Crystals");
        if (lifecrystals != -1)
        {
            tasks.Insert(lifecrystals + 1, new PassLegacy("Adding Mana Crystals", World.Passes.ManaCrystal.Method));
        }

        int iceWalls = tasks.FindIndex(genpass => genpass.Name == "Ice Walls");
        if (iceWalls != -1)
        {
            tasks.Insert(iceWalls + 1, new PassLegacy("Avalon Shrines", World.Passes.Shrines.Method));
        }

        int weeds = tasks.FindIndex(genpass => genpass.Name == "Weeds");
        if (weeds != -1)
        {
            tasks.Insert(weeds + 1, new PassLegacy("Contagion weeds", World.Passes.Plants.Method));
        }

        int microBiomes = tasks.FindIndex(genpass => genpass.Name == "Micro Biomes");
        if (microBiomes != -1)
        {
            tasks.RemoveAt(microBiomes);
            //tasks.Insert(microBiomes, new PassLegacy("Avalon Contaigon fix 1", delegate (GenerationProgress progress)
            //{
            //    if (contaigon) WorldGen.crimson = true;
            //}));
            tasks.Insert(microBiomes + 1, new PassLegacy("Avalon Micro Biomes Fix", World.Passes.MicroBiomes.Method));
            tasks.Insert(microBiomes + 1, new PassLegacy("Replacing items in chests", World.Passes.ReplaceChestItems.Method));

            //tasks.Insert(microBiomes + 1, new PassLegacy("Nest Test", World.Passes.TuhrtlOutpost.Method));
            //tasks.Insert(microBiomes + 1, new PassLegacy("Nest", World.Passes.WaspNest.Method));
        }
    }

    public void SpreadXanthophyte(int x, int y)
    {
        if (Main.tile[x, y].IsActuated)
        {
            return;
        }

        int type = Main.tile[x, y].TileType;

        if (y > (Main.worldSurface + Main.rockLayer) / 2.0)
        {
            if ((type == ModContent.TileType<Tiles.TropicalGrass>()/* || type == ModContent.TileType<Tiles.BrownIce>()*/) && WorldGen.genRand.Next(325) == 0)
            {
                int num6 = x + WorldGen.genRand.Next(-10, 11);
                int num7 = y + WorldGen.genRand.Next(-10, 11);
                if (Main.tile[num6, num7].HasTile && (Main.tile[num6, num7].TileType == ModContent.TileType<Tiles.TropicalMud>()/* || Main.tile[num6, num7].type == ModContent.TileType<Tiles.BrownIce>()*/) && (!Main.tile[num6, num7 - 1].HasTile || (Main.tile[num6, num7 - 1].TileType != 5 && Main.tile[num6, num7 - 1].TileType != 236 && Main.tile[num6, num7 - 1].TileType != 238)) && GrowingOreSpread.GrowingOre(x, y, ModContent.TileType<Tiles.Ores.XanthophyteOre>()))
                {
                    Main.tile[num6, num7].TileType = (ushort)ModContent.TileType<Tiles.Ores.XanthophyteOre>();
                    WorldGen.SquareTileFrame(num6, num7, true);
                }
            }
            if (type == (ushort)ModContent.TileType<Tiles.Ores.XanthophyteOre>() && WorldGen.genRand.Next(3) != 0)
            {
                int num8 = x;
                int num9 = y;
                int num10 = WorldGen.genRand.Next(4);
                if (num10 == 0)
                {
                    num8++;
                }
                if (num10 == 1)
                {
                    num8--;
                }
                if (num10 == 2)
                {
                    num9++;
                }
                if (num10 == 3)
                {
                    num9--;
                }
                if (Main.tile[num8, num9].HasTile && (Main.tile[num8, num9].TileType == ModContent.TileType<TropicalMud>() || Main.tile[num8, num9].TileType == ModContent.TileType<TropicalGrass>()) /*|| Main.tile[num8, num9].type == ModContent.TileType<Tiles.BrownIce>())*/ && GrowingOreSpread.GrowingOre(x, y, ModContent.TileType<Tiles.Ores.XanthophyteOre>()))
                {
                    Main.tile[num8, num9].TileType = (ushort)ModContent.TileType<Tiles.Ores.XanthophyteOre>();
                    WorldGen.SquareTileFrame(num8, num9, true);
                }
            }

            /*if ((type == 70) && WorldGen.genRand.Next(150) == 0)
            {
                int num6 = x + WorldGen.genRand.Next(-10, 11);
                int num7 = y + WorldGen.genRand.Next(-10, 11);
                if (Main.tile[num6, num7].HasTile && (Main.tile[num6, num7].type == 59 || Main.tile[num6, num7].type == 70) && (!Main.tile[num6, num7 - 1].HasTile || (Main.tile[num6, num7 - 1].type != 5 && Main.tile[num6, num7 - 1].type != 236 && Main.tile[num6, num7 - 1].type != 238)) && WorldGen.Shroomite(num6, num7))
                {
                    Main.tile[num6, num7].type = 406;
                    WorldGen.SquareTileFrame(num6, num7, true);
                }
            }
            if (type == 406 && WorldGen.genRand.Next(3) != 0)
            {
                int num8 = i;
                int num9 = j;
                int num10 = WorldGen.genRand.Next(4);
                if (num10 == 0)
                {
                    num8++;
                }
                if (num10 == 1)
                {
                    num8--;
                }
                if (num10 == 2)
                {
                    num9++;
                }
                if (num10 == 3)
                {
                    num9--;
                }
                if (Main.tile[num8, num9].HasTile && (Main.tile[num8, num9].type == 59 || Main.tile[num8, num9].type == 70) && WorldGen.Shroomite(num8, num9))
                {
                    Main.tile[num8, num9].type = 406;
                    WorldGen.SquareTileFrame(num8, num9, true);
                }
            }

            if ((type == 161 || type == 163 || type == 164 || type == 200 || type == 361) && WorldGen.genRand.Next(150) == 0)
            {
                int num6 = i + WorldGen.genRand.Next(-10, 11);
                int num7 = j + WorldGen.genRand.Next(-10, 11);
                if (Main.tile[num6, num7].HasTile && (Main.tile[num6, num7].type == 161 || Main.tile[num6, num7].type == 163 || Main.tile[num6, num7].type == 164 || Main.tile[num6, num7].type == 200 || Main.tile[num6, num7].type == 361) && (!Main.tile[num6, num7 - 1].HasTile || (Main.tile[num6, num7 - 1].type != 5 && Main.tile[num6, num7 - 1].type != 236 && Main.tile[num6, num7 - 1].type != 238)) && WorldGen.Ferozium(num6, num7))
                {
                    Main.tile[num6, num7].type = 379;
                    WorldGen.SquareTileFrame(num6, num7, true);
                }
            }
            if (type == 379 && WorldGen.genRand.Next(3) != 0)
            {
                int num8 = i;
                int num9 = j;
                int num10 = WorldGen.genRand.Next(4);
                if (num10 == 0)
                {
                    num8++;
                }
                if (num10 == 1)
                {
                    num8--;
                }
                if (num10 == 2)
                {
                    num9++;
                }
                if (num10 == 3)
                {
                    num9--;
                }
                if (Main.tile[num8, num9].HasTile && (Main.tile[num8, num9].type == 161 || Main.tile[num8, num9].type == 164 || Main.tile[num8, num9].type == 361 || Main.tile[num8, num9].type == 163 || Main.tile[num8, num9].type == 200 || Main.tile[num8, num9].type == 411) && WorldGen.Ferozium(num8, num9))
                {
                    Main.tile[num8, num9].type = 379;
                    WorldGen.SquareTileFrame(num8, num9, true);
                }
            }*/
        }
    }

    #region growhelltree
    /*public static bool GrowHellTree(int i, int y)
    {
        int j;
        for (j = y; TileLoader.IsSapling(Main.tile[i, j].TileType); j--)
        {
        }
        if ((Main.tile[i - 1, j - 1].liquid != 0 || Main.tile[i, j - 1].liquid != 0 || Main.tile[i + 1, j - 1].liquid != 0) && Main.tile[i, j].TileType != 60)
        {
            return false;
        }
        if (Main.tile[i, j].HasUnactuatedTile && !Main.tile[i, j].IsHalfBlock && Main.tile[i, j].slope() == 0 && TileLoader.CanGrowModTree(Main.tile[i - 1, j].TileType) || TileLoader.CanGrowModTree(Main.tile[i + 1, j].TileType) || TileLoader.CanGrowModTree(Main.tile[i, j].TileType))
        {
            int num = 2;
            int maxTreeHeight = 16;
            if (WorldGen.EmptyTileCheck(i - num, i + num, j + maxTreeHeight, j + 1, TileID.Saplings))
            {
                bool flag = false;
                bool flag2 = false;
                int heightOfTree = WorldGen.genRand.Next(5, maxTreeHeight + 1);
                int num4;
                for (int k = j + heightOfTree; k > j; k--)
                {
                    Main.tile[i, k].frameNumber((byte)WorldGen.genRand.Next(3));
                    Main.tile[i, k].active(active: true);
                    Main.tile[i, k].TileType = 5;
                    num4 = WorldGen.genRand.Next(3);
                    int num5 = WorldGen.genRand.Next(10);
                    if (k == j + 1 || k == j + heightOfTree)
                    {
                        num5 = 0;
                    }
                    while (((num5 == 5 || num5 == 7) && flag) || ((num5 == 6 || num5 == 7) && flag2))
                    {
                        num5 = WorldGen.genRand.Next(10);
                    }
                    flag = false;
                    flag2 = false;
                    if (num5 == 5 || num5 == 7)
                    {
                        flag = true;
                    }
                    if (num5 == 6 || num5 == 7)
                    {
                        flag2 = true;
                    }
                    switch (num5)
                    {
                        case 1:
                            if (num4 == 0)
                            {
                                Main.tile[i, k].TileFrameX = 0;
                                Main.tile[i, k].TileFrameY = 176; // changed - 66
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i, k].TileFrameX = 0;
                                Main.tile[i, k].TileFrameY = 154; // changed - 88
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i, k].TileFrameX = 0;
                                Main.tile[i, k].TileFrameY = 132; // changed - 110
                            }
                            break;

                        case 2:
                            if (num4 == 0)
                            {
                                Main.tile[i, k].TileFrameX = 22;
                                Main.tile[i, k].TileFrameY = 242; // changed - 0
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i, k].TileFrameX = 22;
                                Main.tile[i, k].TileFrameY = 220; // changed - 22
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i, k].TileFrameX = 22;
                                Main.tile[i, k].TileFrameY = 198; // changed - 44
                            }
                            break;

                        case 3:
                            if (num4 == 0)
                            {
                                Main.tile[i, k].TileFrameX = 44;
                                Main.tile[i, k].TileFrameY = 176; // changed - 66
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i, k].TileFrameX = 44;
                                Main.tile[i, k].TileFrameY = 154; // changed - 88
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i, k].TileFrameX = 44;
                                Main.tile[i, k].TileFrameY = 132; // changed - 110
                            }
                            break;

                        case 4:
                            if (num4 == 0) // changed - 66 88 110
                            {
                                Main.tile[i, k].TileFrameX = 22;
                                Main.tile[i, k].TileFrameY = 176;
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i, k].TileFrameX = 22;
                                Main.tile[i, k].TileFrameY = 154;
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i, k].TileFrameX = 22;
                                Main.tile[i, k].TileFrameY = 132;
                            }
                            break;

                        case 5:
                            if (num4 == 0) // changed - 0 22 44
                            {
                                Main.tile[i, k].TileFrameX = 88;
                                Main.tile[i, k].TileFrameY = 242;
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i, k].TileFrameX = 88;
                                Main.tile[i, k].TileFrameY = 220;
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i, k].TileFrameX = 88;
                                Main.tile[i, k].TileFrameY = 198;
                            }
                            break;

                        case 6:
                            if (num4 == 0) // changed - 66 88 110
                            {
                                Main.tile[i, k].TileFrameX = 66;
                                Main.tile[i, k].TileFrameY = 176;
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i, k].TileFrameX = 66;
                                Main.tile[i, k].TileFrameY = 154;
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i, k].TileFrameX = 66;
                                Main.tile[i, k].TileFrameY = 132;
                            }
                            break;

                        case 7:
                            if (num4 == 0) // 66 88 110
                            {
                                Main.tile[i, k].TileFrameX = 110;
                                Main.tile[i, k].TileFrameY = 176;
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i, k].TileFrameX = 110;
                                Main.tile[i, k].TileFrameY = 154;
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i, k].TileFrameX = 110;
                                Main.tile[i, k].TileFrameY = 132;
                            }
                            break;

                        default:
                            if (num4 == 0) // 0 22 44
                            {
                                Main.tile[i, k].TileFrameX = 0;
                                Main.tile[i, k].TileFrameY = 242;
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i, k].TileFrameX = 0;
                                Main.tile[i, k].TileFrameY = 220;
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i, k].TileFrameX = 0;
                                Main.tile[i, k].TileFrameY = 198;
                            }
                            break;
                    }
                    if (num5 == 5 || num5 == 7)
                    {
                        Main.tile[i - 1, k].active(active: true);
                        Main.tile[i - 1, k].TileType = 5;
                        num4 = WorldGen.genRand.Next(3);
                        if (WorldGen.genRand.Next(3) < 2)
                        {
                            if (num4 == 0) // 198 220 242
                            {
                                Main.tile[i - 1, k].TileFrameX = 44;
                                Main.tile[i - 1, k].TileFrameY = 44;
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i - 1, k].TileFrameX = 44;
                                Main.tile[i - 1, k].TileFrameY = 22;
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i - 1, k].TileFrameX = 44;
                                Main.tile[i - 1, k].TileFrameY = 0;
                            }
                        }
                        else
                        {
                            if (num4 == 0) // 0 22 44
                            {
                                Main.tile[i - 1, k].TileFrameX = 66;
                                Main.tile[i - 1, k].TileFrameY = 242;
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i - 1, k].TileFrameX = 66;
                                Main.tile[i - 1, k].TileFrameY = 220;
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i - 1, k].TileFrameX = 66;
                                Main.tile[i - 1, k].TileFrameY = 198;
                            }
                        }
                    }
                    if (num5 != 6 && num5 != 7)
                    {
                        continue;
                    }
                    Main.tile[i + 1, k].active(active: true);
                    Main.tile[i + 1, k].TileType = 5;
                    num4 = WorldGen.genRand.Next(3);
                    if (WorldGen.genRand.Next(3) < 2)
                    {
                        if (num4 == 0) // 198 220 242
                        {
                            Main.tile[i + 1, k].TileFrameX = 66;
                            Main.tile[i + 1, k].TileFrameY = 44;
                        }
                        if (num4 == 1)
                        {
                            Main.tile[i + 1, k].TileFrameX = 66;
                            Main.tile[i + 1, k].TileFrameY = 22;
                        }
                        if (num4 == 2)
                        {
                            Main.tile[i + 1, k].TileFrameX = 66;
                            Main.tile[i + 1, k].TileFrameY = 0;
                        }
                    }
                    else
                    {
                        if (num4 == 0) // 66 88 110
                        {
                            Main.tile[i + 1, k].TileFrameX = 88;
                            Main.tile[i + 1, k].TileFrameY = 176;
                        }
                        if (num4 == 1)
                        {
                            Main.tile[i + 1, k].TileFrameX = 88;
                            Main.tile[i + 1, k].TileFrameY = 154;
                        }
                        if (num4 == 2)
                        {
                            Main.tile[i + 1, k].TileFrameX = 88;
                            Main.tile[i + 1, k].TileFrameY = 132;
                        }
                    }
                }
                int num6 = WorldGen.genRand.Next(3);
                bool flag3 = false;
                bool flag4 = false;
                if (Main.tile[i - 1, j].HasUnactuatedTile && !Main.tile[i - 1, j].IsHalfBlock && Main.tile[i - 1, j].slope() == 0 && (Main.tile[i - 1, j].TileType == 2 || Main.tile[i - 1, j].TileType == 23 || Main.tile[i - 1, j].TileType == 60 || Main.tile[i - 1, j].TileType == 109 || Main.tile[i - 1, j].TileType == 147 || Main.tile[i - 1, j].TileType == 199 || TileLoader.CanGrowModTree(Main.tile[i - 1, j].TileType)))
                {
                    flag3 = true;
                }
                if (Main.tile[i + 1, j].HasUnactuatedTile && !Main.tile[i + 1, j].IsHalfBlock && Main.tile[i + 1, j].slope() == 0 && (Main.tile[i + 1, j].TileType == 2 || Main.tile[i + 1, j].TileType == 23 || Main.tile[i + 1, j].TileType == 60 || Main.tile[i + 1, j].TileType == 109 || Main.tile[i + 1, j].TileType == 147 || Main.tile[i + 1, j].TileType == 199 || TileLoader.CanGrowModTree(Main.tile[i + 1, j].TileType)))
                {
                    flag4 = true;
                }
                if (!flag3)
                {
                    if (num6 == 0)
                    {
                        num6 = 2;
                    }
                    if (num6 == 1)
                    {
                        num6 = 3;
                    }
                }
                if (!flag4)
                {
                    if (num6 == 0)
                    {
                        num6 = 1;
                    }
                    if (num6 == 2)
                    {
                        num6 = 3;
                    }
                }
                if (flag3 && !flag4)
                {
                    num6 = 2;
                }
                if (flag4 && !flag3)
                {
                    num6 = 1;
                }
                if (num6 == 0 || num6 == 1)
                {
                    Main.tile[i + 1, j - 1].active(active: true);
                    Main.tile[i + 1, j - 1].TileType = 5;
                    num4 = WorldGen.genRand.Next(3);
                    if (num4 == 0) // 132 154 176
                    {
                        Main.tile[i + 1, j - 1].TileFrameX = 22;
                        Main.tile[i + 1, j - 1].TileFrameY = 110;
                    }
                    if (num4 == 1)
                    {
                        Main.tile[i + 1, j - 1].TileFrameX = 22;
                        Main.tile[i + 1, j - 1].TileFrameY = 88;
                    }
                    if (num4 == 2)
                    {
                        Main.tile[i + 1, j - 1].TileFrameX = 22;
                        Main.tile[i + 1, j - 1].TileFrameY = 66;
                    }
                }
                if (num6 == 0 || num6 == 2)
                {
                    Main.tile[i - 1, j - 1].active(active: true);
                    Main.tile[i - 1, j - 1].TileType = 5;
                    num4 = WorldGen.genRand.Next(3);
                    if (num4 == 0) // 132 154 176
                    {
                        Main.tile[i - 1, j - 1].TileFrameX = 44;
                        Main.tile[i - 1, j - 1].TileFrameY = 110;
                    }
                    if (num4 == 1)
                    {
                        Main.tile[i - 1, j - 1].TileFrameX = 44;
                        Main.tile[i - 1, j - 1].TileFrameY = 88;
                    }
                    if (num4 == 2)
                    {
                        Main.tile[i - 1, j - 1].TileFrameX = 44;
                        Main.tile[i - 1, j - 1].TileFrameY = 66;
                    }
                }
                num4 = WorldGen.genRand.Next(3);
                switch (num6)
                {
                    case 0:
                        if (num4 == 0) // 132 154 176
                        {
                            Main.tile[i, j - 1].TileFrameX = 88;
                            Main.tile[i, j - 1].TileFrameY = 110;
                        }
                        if (num4 == 1)
                        {
                            Main.tile[i, j - 1].TileFrameX = 88;
                            Main.tile[i, j - 1].TileFrameY = 88;
                        }
                        if (num4 == 2)
                        {
                            Main.tile[i, j - 1].TileFrameX = 88;
                            Main.tile[i, j - 1].TileFrameY = 66;
                        }
                        break;

                    case 1:
                        if (num4 == 0) // 132 154 176
                        {
                            Main.tile[i, j - 1].TileFrameX = 0;
                            Main.tile[i, j - 1].TileFrameY = 110;
                        }
                        if (num4 == 1)
                        {
                            Main.tile[i, j - 1].TileFrameX = 0;
                            Main.tile[i, j - 1].TileFrameY = 88;
                        }
                        if (num4 == 2)
                        {
                            Main.tile[i, j - 1].TileFrameX = 0;
                            Main.tile[i, j - 1].TileFrameY = 66;
                        }
                        break;

                    case 2:
                        if (num4 == 0) // 132 154 176
                        {
                            Main.tile[i, j - 1].TileFrameX = 66;
                            Main.tile[i, j - 1].TileFrameY = 110;
                        }
                        if (num4 == 1)
                        {
                            Main.tile[i, j - 1].TileFrameX = 66;
                            Main.tile[i, j - 1].TileFrameY = 88;
                        }
                        if (num4 == 2)
                        {
                            Main.tile[i, j - 1].TileFrameX = 66;
                            Main.tile[i, j - 1].TileFrameY = 66;
                        }
                        break;
                }
                if (WorldGen.genRand.Next(8) != 0)
                {
                    num4 = WorldGen.genRand.Next(3);
                    if (num4 == 0) // 198 220 242
                    {
                        Main.tile[i, j - heightOfTree].TileFrameX = 22;
                        Main.tile[i, j - heightOfTree].TileFrameY = 44;
                    }
                    if (num4 == 1)
                    {
                        Main.tile[i, j - heightOfTree].TileFrameX = 22;
                        Main.tile[i, j - heightOfTree].TileFrameY = 22;
                    }
                    if (num4 == 2)
                    {
                        Main.tile[i, j - heightOfTree].TileFrameX = 22;
                        Main.tile[i, j - heightOfTree].TileFrameY = 0;
                    }
                }
                else
                {
                    num4 = WorldGen.genRand.Next(3);
                    if (num4 == 0) // 198 220 242
                    {
                        Main.tile[i, j - heightOfTree].TileFrameX = 0;
                        Main.tile[i, j - heightOfTree].TileFrameY = 44;
                    }
                    if (num4 == 1)
                    {
                        Main.tile[i, j - heightOfTree].TileFrameX = 0;
                        Main.tile[i, j - heightOfTree].TileFrameY = 22;
                    }
                    if (num4 == 2)
                    {
                        Main.tile[i, j - heightOfTree].TileFrameX = 0;
                        Main.tile[i, j - heightOfTree].TileFrameY = 0;
                    }
                }
                WorldGen.RangeFrame(i - 2, j + heightOfTree - 1, i + 2, j + 1);
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendTileSquare(-1, i, (int)(j - heightOfTree * 0.5), heightOfTree + 1);
                }
                return true;
            }
        }
        return false;
    }*/
    #endregion

    public void DropComet(int tile)
    {
        bool flag = true;
        int num = 0;
        if (Main.netMode == NetmodeID.MultiplayerClient)
        {
            return;
        }
        for (int i = 0; i < 255; i++)
        {
            if (Main.player[i].active)
            {
                flag = false;
                break;
            }
        }
        int num2 = 0;
        float num3 = Main.maxTilesX / 4200;
        int num4 = (int)(400f * num3);
        for (int j = 5; j < Main.maxTilesX - 5; j++)
        {
            int num5 = 5;
            while (num5 < Main.worldSurface)
            {
                if (Main.tile[j, num5].HasTile && Main.tile[j, num5].TileType == tile)
                {
                    num2++;
                    if (num2 > num4)
                    {
                        return;
                    }
                }
                num5++;
            }
        }
        while (!flag)
        {
            float num6 = Main.maxTilesX * 0.08f;
            int num7 = Main.rand.Next(50, Main.maxTilesX - 50);
            while (num7 > Main.spawnTileX - num6 && num7 < Main.spawnTileX + num6)
            {
                num7 = Main.rand.Next(50, Main.maxTilesX - 50);
            }
            for (int k = Main.rand.Next(100); k < Main.maxTilesY; k++)
            {
                if (Main.tile[num7, k].HasTile && Main.tileSolid[Main.tile[num7, k].TileType])
                {
                    flag = Comet(num7, k, tile);
                    break;
                }
            }
            num++;
            if (num >= 100)
            {
                return;
            }
        }
    }

    public bool Comet(int i, int j, int tile)
    {
        if (i < 50 || i > Main.maxTilesX - 50)
        {
            return false;
        }
        if (j < 50 || j > Main.maxTilesY - 50)
        {
            return false;
        }
        int num = 25;
        var rectangle = new Rectangle((i - num) * 16, (j - num) * 16, num * 2 * 16, num * 2 * 16);
        for (int k = 0; k < 255; k++)
        {
            if (Main.player[k].active)
            {
                var value = new Rectangle((int)(Main.player[k].position.X + Main.player[k].width / 2 - NPC.sWidth / 2 - NPC.safeRangeX), (int)(Main.player[k].position.Y + Main.player[k].height / 2 - NPC.sHeight / 2 - NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
                if (rectangle.Intersects(value))
                {
                    return false;
                }
            }
        }
        for (int l = 0; l < 200; l++)
        {
            if (Main.npc[l].active)
            {
                var value2 = new Rectangle((int)Main.npc[l].position.X, (int)Main.npc[l].position.Y, Main.npc[l].width, Main.npc[l].height);
                if (rectangle.Intersects(value2))
                {
                    return false;
                }
            }
        }
        for (int m = i - num; m < i + num; m++)
        {
            for (int n = j - num; n < j + num; n++)
            {
                if (Main.tile[m, n].HasTile && Main.tile[m, n].TileType == 21 || Main.tile[m, n].TileType == TileID.Containers2)
                {
                    return false;
                }
            }
        }
        stopCometDrops = true;
        num = 15;
        for (int num2 = i - num; num2 < i + num; num2++)
        {
            for (int num3 = j - num; num3 < j + num; num3++)
            {
                if (num3 > j + Main.rand.Next(-2, 3) - 5 && Math.Abs(i - num2) + Math.Abs(j - num3) < num * 1.5 + Main.rand.Next(-5, 5))
                {
                    if (!Main.tileSolid[Main.tile[num2, num3].TileType])
                    {
                        WorldGen.KillTile(num2, num3, noItem: true);
                        //Main.tile[num2, num3].active(false);
                    }
                    Main.tile[num2, num3].TileType = (ushort)tile;
                }
            }
        }
        num = 10;
        for (int num4 = i - num; num4 < i + num; num4++)
        {
            for (int num5 = j - num; num5 < j + num; num5++)
            {
                if (num5 > j + Main.rand.Next(-2, 3) - 5 && Math.Abs(i - num4) + Math.Abs(j - num5) < num + Main.rand.Next(-3, 4))
                {
                    WorldGen.KillTile(num4, num5, noItem: true);
                    //Main.tile[num4, num5].active(false);
                }
            }
        }
        num = 16;
        for (int num6 = i - num; num6 < i + num; num6++)
        {
            for (int num7 = j - num; num7 < j + num; num7++)
            {
                if (Main.tile[num6, num7].TileType == 5 || Main.tile[num6, num7].TileType == 32)
                {
                    WorldGen.KillTile(num6, num7, false, false, false);
                }
                WorldGen.SquareTileFrame(num6, num7, true);
                WorldGen.SquareWallFrame(num6, num7, true);
            }
        }
        num = 23;
        for (int num8 = i - num; num8 < i + num; num8++)
        {
            for (int num9 = j - num; num9 < j + num; num9++)
            {
                if (Main.tile[num8, num9].HasTile && Main.rand.Next(10) == 0 && Math.Abs(i - num8) + Math.Abs(j - num9) < num * 1.3)
                {
                    if (Main.tile[num8, num9].TileType == 5 || Main.tile[num8, num9].TileType == 32)
                    {
                        WorldGen.KillTile(num8, num9, false, false, false);
                    }
                    Main.tile[num8, num9].TileType = (ushort)tile;
                    WorldGen.SquareTileFrame(num8, num9, true);
                }
            }
        }
        stopCometDrops = false;
        if (Main.netMode == NetmodeID.SinglePlayer)
        {
            Main.NewText("A comet has struck ground!", 0, 201, 190);
        }
        else if (Main.netMode == NetmodeID.Server)
        {
            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("A comet has struck ground!"), new Color(0, 201, 190));
        }
        if (Main.netMode != NetmodeID.MultiplayerClient)
        {
            NetMessage.SendTileSquare(-1, i, j, 30);
        }
        return true;
    }

    public void InitiateSuperHardmode()
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(shmCallback), 1);
    }
    public void GenerateSkyFortress()
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(SkyFortressCallback), 1);
    }
    public void GenerateCrystalMines()
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(CrystalMinesCallback), 1);
    }
    public void SkyFortressCallback(object threadContext)
    {
        if (Main.rand == null)
        {
            Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
        }
        //if (!ExxoAvalonOriginsGlobalNPC.stoppedArmageddon) return;
        int x = Main.maxTilesX / 3;
        int xStored = x;
        int y = 50;
        if (Main.maxTilesY == 1800) y = 60;
        if (Main.maxTilesY == 2400) y = 70;
        if (Main.rand.Next(2) == 0)
        {
            x = Main.maxTilesX - Main.maxTilesX / 3;


            //for (int i = x; i < x + 210; i++)
            //{
            //    for (int j = y; j < y + 158; j++)
            //    {
            //        if (Main.tile[i, j].HasTile || Main.tile[i, j].liquid > 0 || Main.tile[i, j].wall > 0)
            //        {
            //            xStored--;
            //            break;
            //        }
            //    }
            //}
        }
        else
        {
            //while (Main.tile[x, y].HasTile || Main.tile[x, y].liquid > 0 || Main.tile[x, y].wall > 0) x++;
        }
        World.Structures.SkyFortress.Generate(x, y);
        if (Main.netMode == NetmodeID.SinglePlayer)
        {
            Main.NewText("Something is hiding on the top of your world...", 244, 140, 140);
        }
        else if (Main.netMode == NetmodeID.Server)
        {
            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Something is hiding on the top of your world..."), new Color(244, 140, 140));
        }
    }
    public void CrystalMinesCallback(object threadContext)
    {
        if (!SuperHardmode) return;
        if (Main.netMode == NetmodeID.SinglePlayer)
        {
            Main.NewText("The otherworldly crystals begin to grow...", 176, 153, 214); // [c/7BBAE4:The ot][c/90ABDD:herwo][c/A3A0D9:rldly] [c/B099D6:cryst][c/BA92D4:als] [c/BA92D4:be][c/C88AD1:gin to] [c/D881CD:grow][c/E37BCB:...]
        }
        else if (Main.netMode == NetmodeID.Server)
        {
            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The otherworldly crystals begin to grow..."), new Color(176, 153, 214));
        }
        float num611 = Main.maxTilesX * Main.maxTilesY / 5040000f;
        int amtOfBiomes = 3;
        if (Main.maxTilesX == 6300) amtOfBiomes = 4;
        if (Main.maxTilesX == 8400) amtOfBiomes = 5;
        //int num612 = (int)(WorldGen.genRand.Next(2, 4) * num611);
        float num613 = (Main.maxTilesX - 160) / amtOfBiomes;
        int num614 = 0;
        while (num614 < amtOfBiomes)
        {
            float num615 = (float)num614 / amtOfBiomes;
            Point point = WorldGen.RandomRectanglePoint((int)(num615 * (Main.maxTilesX - 160)) + 80, (int)Main.rockLayer + 20, (int)num613, Main.maxTilesY - ((int)Main.rockLayer + 40) - 200);
            //CrystalMinesRunner(point.X, point.Y, 150, 150);
            //Biomes<World.Biomes.CrystalMinesHouseBiome>.Place(new Point(point.X, point.Y), null);
            //num614++;
            WorldGenConfiguration config = WorldGenConfiguration.FromEmbeddedPath("Terraria.GameContent.WorldBuilding.Configuration.json");
            World.Biomes.CrystalMines crystalMines = config.CreateBiome<World.Biomes.CrystalMines>();
            if (crystalMines.Place(point, null))
            {
                World.Biomes.CrystalMinesHouseBiome crystalHouse = config.CreateBiome<World.Biomes.CrystalMinesHouseBiome>();
                crystalHouse.Place(new Point(point.X, point.Y + 15), null);
                num614++;
            }
        }
    }

    public static void CrystalMinesRunner(int i, int j, double strength, int steps)
    {
        double num = strength;
        float num2 = steps;
        Vector2 vector = default;
        vector.X = i;
        vector.Y = j;
        Vector2 vector2 = default;
        vector2.X = WorldGen.genRand.Next(-10, 11) * 0.1f;
        vector2.Y = WorldGen.genRand.Next(-10, 11) * 0.1f;
        while (num > 0.0 && num2 > 0f)
        {
            num = strength * (num2 / steps);
            num2 -= 1f;
            int num3 = (int)(vector.X - num * 0.5);
            int num4 = (int)(vector.X + num * 0.5);
            int num5 = (int)(vector.Y - num * 0.5);
            int num6 = (int)(vector.Y + num * 0.5);
            if (num3 < 0)
            {
                num3 = 0;
            }
            if (num4 > Main.maxTilesX)
            {
                num4 = Main.maxTilesX;
            }
            if (num5 < 0)
            {
                num5 = 0;
            }
            if (num6 > Main.maxTilesY)
            {
                num6 = Main.maxTilesY;
            }
            for (int k = num3; k < num4; k++)
            {
                for (int l = num5; l < num6; l++)
                {
                    if (Main.tile[k, l].TileType == 165 || Main.tile[k, l].TileType == 185 || Main.tile[k, l].TileType == 186 ||
                        Main.tile[k, l].TileType == 187)
                    {
                        Tile t = Main.tile[k, l];
                        t.HasTile = false;
                    }
                    if (Math.Abs(k - vector.X) + Math.Abs(l - vector.Y) < strength * 0.5 * (1.0 + WorldGen.genRand.Next(-10, 11) * 0.015) && (TileID.Sets.CanBeClearedDuringOreRunner[Main.tile[k, l].TileType] || Main.tileMoss[Main.tile[k, l].TileType]))
                    {
                        if (Main.tile[k, l].HasTile)
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<CrystalStone>();
                            WorldGen.SquareTileFrame(k, l);
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendTileSquare(-1, k, l, 1);
                            }
                        }
                        else
                        {
                            Main.tile[k, l].WallType = (ushort)ModContent.WallType<Walls.CrystalStoneWall>();
                            WorldGen.SquareWallFrame(k, l);
                        }
                    }
                }
            }
            vector += vector2;
            vector2.X += WorldGen.genRand.Next(-10, 11) * 0.05f;
            if (vector2.X > 1f)
            {
                vector2.X = 1f;
            }
            if (vector2.X < -1f)
            {
                vector2.X = -1f;
            }
        }
    }

    public void shmCallback(object threadContext)
    {
        if (SuperHardmode)
        {
            return;
        }

        GenerateSHMOres();
        SuperHardmode = true;
        if (Main.netMode == NetmodeID.SinglePlayer)
        {
            Main.NewText("The ancient souls have been disturbed...", 255, 60, 0);
            Main.NewText("The heavens above are rumbling...", 50, 255, 130);
            Main.NewText("Your world has been blessed with the elements!", 0, 255, 0);
        }
        else if (Main.netMode == NetmodeID.Server)
        {
            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The ancient souls have been disturbed..."), new Color(255, 60, 0));
            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The heavens above are rumbling..."), new Color(50, 255, 130));
            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with the elements!"), new Color(0, 255, 0));
        }
        if (Main.netMode == NetmodeID.Server)
        {
            Netplay.ResetSections();
        }
    }

    public static void GenerateSHMOres()
    {
        if (Main.rand == null)
        {
            Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
        }
        // oblivion ore
        for (int a = 0; a < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); a++)
        {
            int x = Main.rand.Next(100, Main.maxTilesX - 100);
            int y = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
            WorldGen.OreRunner(x, y, Main.rand.Next(5, 9), Main.rand.Next(4, 6), (ushort)ModContent.TileType<Tiles.Ores.OblivionOre>());
        }
        // opals
        for (int a = 0; a < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); a++)
        {
            int x = Main.rand.Next(100, Main.maxTilesX - 100);
            int y = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
            WorldGen.OreRunner(x, y, Main.rand.Next(4, 7), Main.rand.Next(1, 4), (ushort)ModContent.TileType<Tiles.Ores.Opal>());
        }
        // onyx
        for (int a = 0; a < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); a++)
        {
            int x = Main.rand.Next(100, Main.maxTilesX - 100);
            int y = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
            WorldGen.OreRunner(x, y, Main.rand.Next(4, 7), Main.rand.Next(1, 4), (ushort)ModContent.TileType<Tiles.Ores.Onyx>());
        }
        // kunzite
        for (int a = 0; a < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); a++)
        {
            int x = Main.rand.Next(100, Main.maxTilesX - 100);
            int y = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
            WorldGen.OreRunner(x, y, Main.rand.Next(4, 7), Main.rand.Next(1, 4), (ushort)ModContent.TileType<Tiles.Ores.Kunzite>());
        }
        // primordial ore
        for (int a = 0; a < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); a++)
        {
            int x = Main.rand.Next(100, Main.maxTilesX - 100);
            int y = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
            WorldGen.OreRunner(x, y, Main.rand.Next(3, 6), Main.rand.Next(5, 8), (ushort)ModContent.TileType<Tiles.Ores.PrimordialOre>());
        }
    }

    public void MakeOblivionOre(NPC npc1, NPC npc2, string text, int radius)
    {
        if (Collision.CheckAABBvAABBCollision(npc1.Center, new Vector2(npc1.width, npc1.height), npc2.Center, new Vector2(npc2.width, npc2.height)))
        {
            Utils.MakeCircle((int)(npc1.position.X / 16f), (int)(npc1.position.Y / 16f), radius, ModContent.TileType<Tiles.Ores.OblivionOre>());
            npc1.life = 0;
            npc1.NPCLoot();
            npc1.active = false;
            SoundEngine.PlaySound(npc1.DeathSound.SoundId, (int)npc1.position.X, (int)npc1.position.Y);
            npc2.life = 0;
            npc2.NPCLoot();
            npc2.active = false;
            SoundEngine.PlaySound(npc2.DeathSound.SoundId, (int)npc2.position.X, (int)npc2.position.Y);
            var color = new Color(135, 78, 0);
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, color);
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), color);
            }
        }
    }

    public override TagCompound Save()
    {
        var toSave = new TagCompound
        {
            { "ExxoAvalonOrigins:LastOpenedVersion", ExxoAvalonOrigins.Mod.Version.ToString() },
            { "ExxoAvalonOrigins:SuperHardMode", SuperHardmode },
            { "ExxoAvalonOrigins:DownedBacteriumPrime", downedBacteriumPrime },
            { "ExxoAvalonOrigins:DownedDesertBeak", downedDesertBeak },
            { "ExxoAvalonOrigins:DownedPhantasm", downedPhantasm },
            { "ExxoAvalonOrigins:DownedDragonLord", downedDragonLord },
            { "ExxoAvalonOrigins:DownedMechasting", downedMechasting },
            { "ExxoAvalonOrigins:DownedOblivion", oblivionDead },
            { "ExxoAvalonOrigins:LibraryofKnowledge", LoK },
            { "ExxoAvalonOrigins:Contagion", contagion },
            { "ExxoAvalonOrigins:DungeonSide", dungeonSide },
            { "ExxoAvalonOrigins:SHMOreTier1", shmOreTier1 },
            { "ExxoAvalonOrigins:SHMOreTier2", shmOreTier2 },
            { "ExxoAvalonOrigins:OsmiumOre", (int)rhodiumOre },
            { "ExxoAvalonOrigins:HallowAltarCount", hallowAltarCount },
            { "ExxoAvalonOrigins:JungleType", (int)jungleMenuSelection },
            { "ExxoAvalonOrigins:WorldDarkMatterTiles", WorldDarkMatterTiles },
            { "ExxoAvalonOrigins:StoppedArmageddon", ExxoAvalonOriginsWorld.stoppedArmageddon },
            { "ExxoAvalonOrigins:SpecialWireHitCount", specialWireHitCount}
        };

        // Update config cache values on save world
        ExxoAvalonOriginsConfig config = ModContent.GetInstance<ExxoAvalonOriginsConfig>();
        Dictionary<string, ExxoAvalonOriginsConfig.WorldDataValues> tempDict = config.GetWorldData();
        ExxoAvalonOriginsConfig.WorldDataValues worldData;

        worldData.contagion = contagion;
        worldData.jungleType = (int)jungleMenuSelection;
        worldData.superHardmode = SuperHardmode;

        string path = Path.ChangeExtension(Main.worldPathName, ".twld");
        tempDict[path] = worldData;
        config.SetWorldData(tempDict);

        ExxoAvalonOriginsConfig.Save(config);

        return toSave;
    }
    public override void Load(TagCompound tag)
    {
        if (tag.ContainsKey("ExxoAvalonOrigins:LastOpenedVersion"))
        {
            worldVersion = new Version(tag["ExxoAvalonOrigins:LastOpenedVersion"].ToString());
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:SuperHardMode"))
        {
            SuperHardmode = tag.Get<bool>("ExxoAvalonOrigins:SuperHardMode");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:DownedBacteriumPrime"))
        {
            downedBacteriumPrime = tag.Get<bool>("ExxoAvalonOrigins:DownedBacteriumPrime");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:DownedDesertBeak"))
        {
            downedDesertBeak = tag.Get<bool>("ExxoAvalonOrigins:DownedDesertBeak");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:DownedPhantasm"))
        {
            downedPhantasm = tag.Get<bool>("ExxoAvalonOrigins:DownedPhantasm");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:DownedDragonLord"))
        {
            downedDragonLord = tag.Get<bool>("ExxoAvalonOrigins:DownedDragonLord");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:DownedMechasting"))
        {
            downedMechasting = tag.Get<bool>("ExxoAvalonOrigins:DownedMechasting");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:DownedOblivion"))
        {
            oblivionDead = tag.Get<bool>("ExxoAvalonOrigins:DownedOblivion");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:LibraryofKnowledge"))
        {
            LoK = tag.Get<Vector2>("ExxoAvalonOrigins:LibraryofKnowledge");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:Contagion"))
        {
            contagion = tag.Get<bool>("ExxoAvalonOrigins:Contagion");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:JungleType"))
        {
            jungleMenuSelection = (JungleVariant)tag.GetAsInt("ExxoAvalonOrigins:JungleType");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:DungeonSide"))
        {
            dungeonSide = tag.GetAsInt("ExxoAvalonOrigins:DungeonSide");
        }
        else
        {
            dungeonSide = -1;
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:SHMOreTier1"))
        {
            shmOreTier1 = tag.GetAsInt("ExxoAvalonOrigins:SHMOreTier1");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:SHMOreTier2"))
        {
            shmOreTier2 = tag.GetAsInt("ExxoAvalonOrigins:SHMOreTier2");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:OsmiumOre"))
        {
            rhodiumOre = (RhodiumVariant)tag.GetAsInt("ExxoAvalonOrigins:OsmiumOre");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:HallowAltarCount"))
        {
            hallowAltarCount = tag.GetAsInt("ExxoAvalonOrigins:HallowAltarCount");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:WorldDarkMatterTiles"))
        {
            WorldDarkMatterTiles = tag.GetAsInt("ExxoAvalonOrigins:WorldDarkMatterTiles");
            if (WorldDarkMatterTiles < 0)
            {
                WorldDarkMatterTiles = 0;
            }
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:StoppedArmageddon"))
        {
            ExxoAvalonOriginsWorld.stoppedArmageddon = tag.Get<bool>("ExxoAvalonOrigins:StoppedArmageddon");
        }
        if (tag.ContainsKey("ExxoAvalonOrigins:SpecialWireHitCount"))
        {
            specialWireHitCount = tag.GetAsInt("ExxoAvalonOrigins:SpecialWireHitCount");
        }
    }
}
