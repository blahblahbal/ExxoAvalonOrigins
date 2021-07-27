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
	public class PearlstoneColumn : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(73, 51, 36));
			//Main.tileBeam[Type] = true;
			drop = mod.ItemType("PearlstoneColumn");
		}
	}
}