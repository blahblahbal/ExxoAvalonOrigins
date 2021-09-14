using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
	public class BrownIce : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(210, 147, 128));
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			drop = mod.ItemType("BrownIceBlock");
            Main.tileMerge[Type][TileID.IceBlock] = true;
            Main.tileMerge[TileID.IceBlock][Type] = true;
			Main.tileShine2[Type] = true;
            soundType = SoundID.Item;
            soundStyle = 50;
            dustType = DustID.Dirt;
        }
	}
}