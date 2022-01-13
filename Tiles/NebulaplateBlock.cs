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
	public class NebulaplateBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(179, 110, 216));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			drop = mod.ItemType("NebulaplateBlock");
            soundType = SoundID.Tink;
            soundStyle = 1;
        }
	}
}