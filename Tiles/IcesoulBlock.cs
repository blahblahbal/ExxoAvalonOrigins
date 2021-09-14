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
	public class IcesoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(0, 0, 200));
			Main.tileSolid[Type] = true;
			drop = ModContent.ItemType<Items.SoulofIce>();
            dustType = ModContent.DustType<Dusts.Dust233>();
		}
	}
}