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
	class DesertLongSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Long Sword");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/DesertLongSword");
			item.UseSound = SoundID.Item1;
			item.damage = 29;
			item.useTurn = true;
			item.scale = 1f;
			item.rare = 2;
			item.width = dims.Width;
			item.useTime = 27;
			item.knockBack = 3f;
			item.melee = true;
			item.useStyle = 1;
			item.value = Item.sellPrice(0, 0, 54, 0);
			item.useAnimation = 27;
			item.height = dims.Height;
		}
	}
}