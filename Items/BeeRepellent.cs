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
	class BeeRepellent : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bee Repellent");
			Tooltip.SetDefault("Provides immunity to Hornets");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BeeRepellent");
			item.buffType = ModContent.BuffType<Buffs.BeeSweet>();
			item.UseSound = SoundID.Item3;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 100;
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 21600;
		}
	}
}