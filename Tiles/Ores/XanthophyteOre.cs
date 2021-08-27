using ExxoAvalonOrigins.Items;using ExxoAvalonOrigins.Tiles;using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.IO;
using System.Threading;
using Terraria;using Terraria.GameContent.Biomes;
using Terraria.GameContent.Generation;using Terraria.ID;using Terraria.Localization;using Terraria.ModLoader;using Terraria.ModLoader.IO;using Terraria.Utilities;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.Tiles.Ores
{
    public class XanthophyteOre : ModTile
    {
        Color xanthophyteColor = new Color(210, 217, 0);
        public override void SetDefaults()
        {
            AddMapEntry(xanthophyteColor, LanguageManager.Instance.GetText("Xanthophyte"));
            Main.tileSolid[Type] = true;
            ExxoAvalonOrigins.MergeWith(Type, ModContent.TileType<TropicalMud>());
            ExxoAvalonOrigins.MergeWith(Type, ModContent.TileType<TropicalGrass>());			Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 775;
            Main.tileSpelunker[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileValue[Type] = 705;
            drop = ModContent.ItemType<Items.Placeable.XanthophyteOre>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Moss_Yellow;
            minPick = 200;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            ExxoAvalonOrigins.MergeWithFrame(i, j, Type, ModContent.TileType<TropicalMud>(), false, false, false, false, resetFrame);
            return false;
        }
    }
}