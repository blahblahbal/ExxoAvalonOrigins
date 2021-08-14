using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles{	public class Zircon : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(102, 66, 43), LanguageManager.Instance.GetText("Zircon"));			Main.tileSolid[Type] = true;			Main.tileMergeDirt[Type] = true;			drop = mod.ItemType("Zircon");            Main.tileMerge[TileID.Stone][Type] = true;            Main.tileMerge[Type][TileID.Stone] = true;            Main.tileBlockLight[Type] = true;            Main.tileSpelunker[Type] = true;            soundType = SoundID.Tink;            soundStyle = 1;            minPick = 55;        }        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }}