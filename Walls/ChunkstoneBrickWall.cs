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
	public class ChunkstoneBrickWall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			drop = mod.ItemType("ChunkstoneBrickWall");
            AddMapEntry(new Color(67, 83, 61));
            dustType = ModContent.DustType<Dusts.ContagionDust>();
		}
	}
}