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
	class ElixirofLife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elixir of Life");
			Tooltip.SetDefault("'It refreshes you'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/ElixirofLife");
			item.potion = true;
			item.useTurn = true;
			item.maxStack = 60;
			item.healLife = 350;
			item.consumable = true;
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.useTime = 17;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.value = 10000;
			item.useAnimation = 17;
			item.height = dims.Height;
            item.UseSound = SoundID.Item3;
        }
	}
}