﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores
{
    public class NickelOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(82, 112, 122), LanguageManager.Instance.GetText("Nickel"));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1050;
            Main.tileValue[Type] = 235;
            Main.tileSpelunker[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.NickelOre>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = ModContent.DustType<Dusts.NickelDust>();
        }
    }
}
