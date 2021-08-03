using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class Kunzite : ModTile	{		public override void SetDefaults()		{			AddMapEntry(Color.HotPink);			Main.tileSolid[Type] = true;			Main.tileMergeDirt[Type] = true;			drop = mod.ItemType("Kunzite");            soundType = SoundID.Tink;            soundStyle = 1;        }        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }}