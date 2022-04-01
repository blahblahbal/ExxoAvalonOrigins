﻿using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class TropicalShortGrass : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileCut[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.AnchorValidTiles = new int[1] { ModContent.TileType<TropicalGrass>() };
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.addTile(Type);
            dustType = DustID.Grass;
            soundStyle = 1;
            soundType = SoundID.Grass;
            AddMapEntry(new Color(58, 188, 32));
            AddMapEntry(new Color(58, 188, 32));
            AddMapEntry(new Color(58, 188, 32));
            AddMapEntry(new Color(58, 188, 32));
            AddMapEntry(new Color(58, 188, 32));
            AddMapEntry(new Color(58, 188, 32));
            AddMapEntry(new Color(58, 188, 32));
            AddMapEntry(new Color(58, 188, 32));
            AddMapEntry(new Color(277, 41, 75), LanguageManager.Instance.GetText("Tropical Shroom"));
        }
        public override ushort GetMapOption(int i, int j)
        {
            return (ushort)(Main.tile[i, j].TileFrameX / 18);
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (Main.tile[i, j].TileFrameX / 18 == 8)
                Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<TropicalShroomCap>());
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (Main.tile[i, j].TileFrameX / 18 == 8)
            {
                Main.tileLighted[Type] = true;
                Color lightColor = new Color(227, 41, 75);
                r = (float)lightColor.R / 200f;
                g = (float)lightColor.G / 200f;
                b = (float)lightColor.B / 200f;
            }
        }
        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            offsetY = 2;
        }
    }
}
