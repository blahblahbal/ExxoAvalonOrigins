﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles;

public class IckyAltar : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(0, 250, 50), LanguageManager.Instance.GetText("Icky Altar"));
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
        TileObjectData.newTile.LavaDeath = false;
        TileObjectData.newTile.CoordinateHeights = new int[]
        {
            16,
            18
        };
        TileObjectData.addTile(Type);
        Main.tileHammer[Type] = true;
        Main.tileLighted[Type] = true;
        Main.tileFrameImportant[Type] = true;
        adjTiles = new int[] { TileID.DemonAltar };
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        var brightness = Main.rand.Next(-5, 6) * 0.0025f;
        r = 0.2f + brightness;
        g = 0.5f + brightness * 2f;
        b = 0.2f;
    }
    public override bool CanExplode(int i, int j)
    {
        return false;
    }
    public override bool CanKillTile(int i, int j, ref bool blockDamaged)
    {
        if (!Main.hardMode) blockDamaged = false;
        return Main.hardMode;
    }
    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        WorldGen.SmashAltar(i, j);
    }
}