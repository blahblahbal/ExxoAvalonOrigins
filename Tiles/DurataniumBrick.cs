using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class DurataniumBrick : ModTile	{		public override void SetDefaults()		{			AddMapEntry(Color.Purple);			Main.tileSolid[Type] = true;			Main.tileMergeDirt[Type] = true;			Main.tileBrick[Type] = true;			drop = mod.ItemType("DurataniumBrick");            soundType = SoundID.Tink;            soundStyle = 1;        }	}}