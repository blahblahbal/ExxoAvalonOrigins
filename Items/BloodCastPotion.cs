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
	class BloodCastPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Cast Potion");
			Tooltip.SetDefault("Adds your max life to your max mana");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BloodCastPotion");
			item.buffType = ModContent.BuffType<Buffs.BloodCast>();
			item.UseSound = SoundID.Item3;
			item.consumable = true;
			item.rare = 2;
			item.width = dims.Width;
			item.useTime = 15;
			item.useStyle = 2;
			item.maxStack = 100;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 18000;
		}
	}
}