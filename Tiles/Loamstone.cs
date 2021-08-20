using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class Loamstone : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(95, 38, 12));			Main.tileSolid[Type] = true;			Main.tileMergeDirt[Type] = true;			Main.tileBlockLight[Type] = true;
			Main.tileMerge[Type][TileID.Stone] = true;
			Main.tileMerge[TileID.Stone][Type] = true;
			Main.tileMerge[Type][ModContent.TileType<TropicalMud>()] = true;
			Main.tileMerge[ModContent.TileType<TropicalMud>()][Type] = true;
			drop = mod.ItemType("LoamstoneBrick");            soundType = SoundID.Tink;            soundStyle = 1;            //dustType = ModContent.DustType<Dusts.ContagionDust>();
        }	}}


