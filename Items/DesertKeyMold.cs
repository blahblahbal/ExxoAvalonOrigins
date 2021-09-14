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
	class DesertKeyMold : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Key Mold");
			Tooltip.SetDefault("Used for crafting a Desert Key");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/DesertKeyMold");
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}