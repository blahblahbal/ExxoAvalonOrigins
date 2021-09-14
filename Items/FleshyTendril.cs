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
	class FleshyTendril : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fleshy Tendril");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/FleshyTendril");
			item.width = dims.Width;
			item.value = 50;
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}