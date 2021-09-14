using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.Enums;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.Tiles
{
    public class LargeHerbsStage4 : ModTile
    {
        public override void SetDefaults()
        {
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            Main.tileFrameImportant[Type] = true;
        }
        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            ExxoAvalonOriginsWorld.CheckLargeHerb(i, j, Type);
            noBreak = true;
            return true;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int item = 0;
            switch (frameX / 18)
            {
                case 0:
                    item = ModContent.ItemType<Items.LargeDaybloom>();
                    break;
                case 1:
                    item = ModContent.ItemType<Items.LargeMoonglow>();
                    break;
                case 2:
                    item = ModContent.ItemType<Items.LargeBlinkroot>();
                    break;
                case 3:
                    item = ModContent.ItemType<Items.LargeDeathweed>();
                    break;
                case 4:
                    item = ModContent.ItemType<Items.LargeWaterleaf>();
                    break;
                case 5:
                    item = ModContent.ItemType<Items.LargeFireblossom>();
                    break;
                case 6:
                    item = ModContent.ItemType<Items.LargeShiverthorn>();
                    break;
                case 7:
                    item = ModContent.ItemType<Items.LargeBloodberry>();
                    break;
                case 8:
                    item = ModContent.ItemType<Items.LargeSweetstem>();
                    break;
                case 9:
                    item = ModContent.ItemType<Items.LargeBarfbush>();
                    break;

            }
            if (item > 0) Item.NewItem(i * 16, j * 16, 16, 48, item);
        }
    }
}