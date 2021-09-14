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
	public class DarkMatterWoodWall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			drop = mod.ItemType("DarkMatterWoodWall");
            AddMapEntry(new Color(56, 40, 63));
            dustType = ModContent.DustType<Dusts.DarkMatterDust>();
		}
	}
}