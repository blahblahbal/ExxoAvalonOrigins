﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class HardenedDarkSand : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(63, 0, 63));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[Type][TileID.Sandstone] = true;
            Main.tileMerge[TileID.Sandstone][Type] = true;
            Main.tileMerge[Type][TileID.HardenedSand] = true;
            Main.tileMerge[TileID.HardenedSand][Type] = true;
            drop = mod.ItemType("HardenedDarkSandBlock");
            dustType = ModContent.DustType<Dusts.DarkMatterDust>();
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!fail)
            {
                ExxoAvalonOriginsWorld.WorldDarkMatterTiles--;
            }
            base.KillTile(i, j, ref fail, ref effectOnly, ref noItem);
        }
    }
}