﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class PlacedGems : ModTile
    {
        public override void SetDefaults()
        {
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.CoordinatePadding = 2;
            //TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 500;
            Main.tileSpelunker[Type] = true;


        }

        // selects the map entry depending on the frameX
        public override ushort GetMapOption(int i, int j)
        {
            return (ushort)(Main.tile[i, j].frameX / 18);
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            int toDrop = 0;
            //Main.NewText("" + Main.tile[i, j].frameX);
            switch (Main.tile[i, j].frameX / 18)
            {
                case 0:
                    toDrop = ModContent.ItemType<Items.Placeable.Tile.Opal>();
                    break;
                case 1:
                    toDrop = ModContent.ItemType<Items.Placeable.Tile.Onyx>();
                    break;
                case 2:
                    toDrop = ModContent.ItemType<Items.Placeable.Tile.Kunzite>();
                    break;
                case 3:
                    toDrop = ModContent.ItemType<Items.Placeable.Tile.Tourmaline>();
                    break;
                case 4:
                    toDrop = ModContent.ItemType<Items.Placeable.Tile.Peridot>();
                    break;
            }
            if (toDrop > 0) Item.NewItem(i * 16, j * 16, 16, 16, toDrop);
        }

        // copy from the vanilla tileframe for placed gems
        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            var tile = Framing.GetTileSafely(i, j);
            var topTile = Framing.GetTileSafely(i, j - 1);
            var bottomTile = Framing.GetTileSafely(i, j + 1);
            var leftTile = Framing.GetTileSafely(i - 1, j);
            var rightTile = Framing.GetTileSafely(i + 1, j);
            var topType = -1;
            var bottomType = -1;
            var leftType = -1;
            var rightType = -1;
            if (topTile.active() && !topTile.bottomSlope())
                bottomType = topTile.type;
            if (bottomTile.active() && !bottomTile.halfBrick() && !bottomTile.topSlope())
                topType = bottomTile.type;
            if (leftTile.active())
                leftType = leftTile.type;
            if (rightTile.active())
                rightType = rightTile.type;
            var variation = WorldGen.genRand.Next(3) * 18;
            if (topType >= 0 && Main.tileSolid[topType] && !Main.tileSolidTop[topType])
            {
                if (tile.frameY < 0 || tile.frameY > 36)
                    tile.frameY = (short)variation;
            }
            else if (leftType >= 0 && Main.tileSolid[leftType] && !Main.tileSolidTop[leftType])
            {
                if (tile.frameY < 108 || tile.frameY > 54)
                    tile.frameY = (short)(108 + variation);
            }
            else if (rightType >= 0 && Main.tileSolid[rightType] && !Main.tileSolidTop[rightType])
            {
                if (tile.frameY < 162 || tile.frameY > 198)
                    tile.frameY = (short)(162 + variation);
            }
            else if (bottomType >= 0 && Main.tileSolid[bottomType] && !Main.tileSolidTop[bottomType])
            {
                if (tile.frameY < 54 || tile.frameY > 90)
                    tile.frameY = (short)(54 + variation);
            }
            else
                WorldGen.KillTile(i, j);
            return true;
        }

        // needed so gems are only allowed to be placed on solid tiles
        public override bool CanPlace(int i, int j)
        {
            return WorldGen.SolidTile(i - 1, j) || WorldGen.SolidTile(i + 1, j) || WorldGen.SolidTile(i, j - 1) || WorldGen.SolidTile(i, j + 1);
        }

        //public override void PlaceInWorld(int i, int j, Item item)
        //{
        //    Main.tile[i, j].frameX = (short)(item.placeStyle * 18);
        //}

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            if (Main.tile[i, j].frameY / 18 < 3)
                offsetY = 2;
        }
    }
}
