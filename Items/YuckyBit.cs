using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class YuckyBit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yucky Bit");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/YuckyBit");
			item.width = dims.Width;
			item.maxStack = 999;
			item.value = 750;
			item.height = dims.Height;
		}
	}
}