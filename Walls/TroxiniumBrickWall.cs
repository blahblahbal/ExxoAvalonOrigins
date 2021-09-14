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
	public class TroxiniumBrickWall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			drop = mod.ItemType("TroxiniumBrickWall");
            AddMapEntry(new Color(180, 88, 0));
			dustType = ModContent.DustType<Dusts.TroxiniumDust>();
		}
	}
}
