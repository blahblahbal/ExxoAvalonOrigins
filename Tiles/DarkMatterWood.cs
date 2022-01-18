﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class DarkMatterWood : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(80, 63, 88));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            drop = mod.ItemType("DarkMatterWood");
            dustType = ModContent.DustType<Dusts.DarkMatterWoodDust>();
        }
    }
}
