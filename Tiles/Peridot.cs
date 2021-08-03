using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles{	public class Peridot : ModTile	{		public override void SetDefaults()		{			AddMapEntry(Color.Lime, LanguageManager.Instance.GetText("Peridot"));			Main.tileSolid[Type] = true;			drop = mod.ItemType("Peridot");            Main.tileBlockLight[Type] = true;            Main.tileSpelunker[Type] = true;            soundType = SoundID.Tink;            soundStyle = 1;            minPick = 55;		}        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }}