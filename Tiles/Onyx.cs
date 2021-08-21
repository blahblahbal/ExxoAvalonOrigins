using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles{	public class Onyx : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(30, 30, 30), LanguageManager.Instance.GetText("Onyx"));			Main.tileSolid[Type] = true;			Main.tileBlockLight[Type] = true;            Main.tileMerge[TileID.Stone][Type] = true;            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileSpelunker[Type] = true;
            drop = mod.ItemType("Onyx");            minPick = 210;            soundType = SoundID.Tink;            soundStyle = 1;            dustType = 54;        }        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }}