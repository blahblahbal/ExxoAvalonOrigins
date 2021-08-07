using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{
    public class LargeHerbsStage3 : ModTile
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
            TileObjectData.addTile(Type);            Main.tileFrameImportant[Type] = true;
        }        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            ExxoAvalonOriginsWorld.CheckLargeHerb(i, j, Type);
            noBreak = true;
            return true;
        }        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int item = 0;
            switch (frameX / 18)
            {
                case 0:
                    item = ModContent.ItemType<Items.LargeDaybloomSeed>();
                    break;
                case 1:
                    item = ModContent.ItemType<Items.LargeMoonglowSeed>();
                    break;
                case 2:
                    item = ModContent.ItemType<Items.LargeBlinkrootSeed>();
                    break;
                case 3:
                    item = ModContent.ItemType<Items.LargeDeathweedSeed>();
                    break;
                case 4:
                    item = ModContent.ItemType<Items.LargeWaterleafSeed>();
                    break;
                case 5:
                    item = ModContent.ItemType<Items.LargeFireblossomSeed>();
                    break;
                case 6:
                    item = ModContent.ItemType<Items.LargeShiverthornSeed>();
                    break;
                case 7:
                    item = ModContent.ItemType<Items.LargeBloodberrySeed>();
                    break;
                case 8:
                    item = ModContent.ItemType<Items.LargeSweetstemSeed>();
                    break;
                case 9:
                    item = ModContent.ItemType<Items.LargeBarfbushSeed>();
                    break;

            }
            if (item > 0) Item.NewItem(i * 16, j * 16, 16, 48, item);
        }
    }}