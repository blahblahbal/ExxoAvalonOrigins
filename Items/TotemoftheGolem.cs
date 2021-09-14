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
	class TotemoftheGolem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Totem of the Golem");
			Tooltip.SetDefault("Teleports you to the Hidden Temple");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TotemoftheGolem");
			item.consumable = false;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.maxStack = 1;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}