using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class OblivionBrick : ModTile	{		public override void SetDefaults()		{			AddMapEntry(Color.DarkViolet);			Main.tileSolid[Type] = true;			Main.tileBlockLight[Type] = true;			drop = mod.ItemType("OblivionBrick");            soundType = SoundID.Tink;            soundStyle = 1;        }	}}