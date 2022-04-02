﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles;

public class EctoplasmSink : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = false;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
        TileObjectData.addTile(Type);
        AddMapEntry(new Color(191, 142, 111), Language.GetText("MapObject.Sink"));
        disableSmartCursor = true;
        adjTiles = new int[] { TileID.Sinks };
        dustType = DustID.Ultrabright;
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Placeable.Furniture.EctoplasmSink>());
    }
}