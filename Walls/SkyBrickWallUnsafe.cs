using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Walls
{
	public class SkyBrickWallUnsafe : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = false;
            AddMapEntry(new Color(79, 79, 59));
            drop = mod.ItemType("SkyBrickWall");
            dustType = DustID.Smoke;
		}
	}
}
