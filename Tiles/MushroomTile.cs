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
	public class MushroomTile : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(237, 160, 69));
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			drop = ItemID.Mushroom;
            dustType = DustID.Amber;
        }
	}
}
