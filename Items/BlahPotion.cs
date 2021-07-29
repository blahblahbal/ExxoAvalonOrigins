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
	class BlahPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blah Potion");
			Tooltip.SetDefault("Various effects");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BlahPotion");
			item.buffType = ModContent.BuffType<Buffs.Blah>();
			item.UseSound = SoundID.Item3;
			item.consumable = false;
			item.rare = -12;
			item.width = dims.Width;
			item.useTime = 15;
			item.useStyle = 2;
			item.maxStack = 1;
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 1080000;
		}
	}
}