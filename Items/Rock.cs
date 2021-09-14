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
	class Rock : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rock");
			Tooltip.SetDefault("Used for crafting the Eye of Oblivion");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Rock");
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.maxStack = 999;
			item.value = 0;
			item.height = dims.Height;
		}
	}
}