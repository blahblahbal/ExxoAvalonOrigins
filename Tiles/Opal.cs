using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles{	public class Opal : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(165, 255, 127), LanguageManager.Instance.GetText("Opal"));			Main.tileSolid[Type] = true;			Main.tileMergeDirt[Type] = true;			Main.tileBlockLight[Type] = true;			drop = mod.ItemType("Opal");
            Main.tileSpelunker[Type] = true;            Main.tileMerge[TileID.Stone][Type] = true;            Main.tileMerge[Type][TileID.Stone] = true;            soundType = SoundID.Tink;            soundStyle = 1;            minPick = 200;            dustType = 1;        }        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }}