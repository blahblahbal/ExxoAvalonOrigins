using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class DarkMatter : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(135, 15, 170));			Main.tileSolid[Type] = true;			Main.tileBlockLight[Type] = true;			drop = mod.ItemType("DarkMatter");            soundType = SoundID.Tink;            soundStyle = 1;        }	}}