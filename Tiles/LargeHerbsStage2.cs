using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class LargeHerbsStage2 : ModTile	{		public override void SetDefaults()		{			TileObjectData.newTile.Width = 1;			TileObjectData.newTile.Height = 3;			TileObjectData.newTile.CoordinateWidth = 16;			TileObjectData.newTile.CoordinateHeights = new int[] {16, 16, 16};			TileObjectData.newTile.CoordinatePadding = 2;			TileObjectData.newTile.DrawYOffset = 2;			TileObjectData.newTile.StyleHorizontal = true;			TileObjectData.addTile(Type);			drop = mod.ItemType("LargeHerbsStage2");		}	}}