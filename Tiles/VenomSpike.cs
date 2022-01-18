﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class VenomSpike : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(132, 65, 172), LanguageManager.Instance.GetText("Venom Spike"));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("VenomSpike");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.PurpleTorch;
        }
        public override bool Slope(int i, int j)
        {
            return false;
        }
    }
}