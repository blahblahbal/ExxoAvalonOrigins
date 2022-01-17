using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Tiles
{
	public class CrystalStone : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(185, 115, 168));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileMerge[Type][TileID.SnowBlock] = true;
			Main.tileMerge[TileID.SnowBlock][Type] = true;
			Main.tileMerge[Type][TileID.Ebonstone] = true;
			Main.tileMerge[TileID.Ebonstone][Type] = true;
			Main.tileMerge[Type][TileID.Crimstone] = true;
			Main.tileMerge[TileID.Crimstone][Type] = true;
			Main.tileMerge[Type][TileID.Stone] = true;
			Main.tileMerge[TileID.Stone][Type] = true;
			Main.tileMerge[Type][TileID.Mud] = true;
			Main.tileMerge[TileID.Mud][Type] = true;
			drop = mod.ItemType("CrystalStoneBlock");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.PinkCrystalShard;
        }
	}
}


