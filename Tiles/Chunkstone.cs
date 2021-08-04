using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class Chunkstone : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(48, 53, 42));			Main.tileSolid[Type] = true;			Main.tileMergeDirt[Type] = true;			Main.tileBlockLight[Type] = true;			TileID.Sets.Conversion.Stone[Type] = true;
			Main.tileMerge[Type][TileID.SnowBlock] = true;
			Main.tileMerge[TileID.SnowBlock][Type] = true;
			Main.tileMerge[Type][TileID.Ebonstone] = true;
			Main.tileMerge[TileID.Ebonstone][Type] = true;
			Main.tileMerge[Type][TileID.Crimstone] = true;
			Main.tileMerge[TileID.Crimstone][Type] = true;
			drop = mod.ItemType("ChunkstoneBlock");            soundType = SoundID.Tink;            soundStyle = 1;            minPick = 60;            dustType = 184;		}	}}