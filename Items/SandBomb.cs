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
	class SandBomb : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sand Bomb");
			Tooltip.SetDefault("An explosion of sand that will not destroy tiles");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/SandBomb");
			item.noUseGraphic = true;
			item.damage = 0;
			item.maxStack = 999;
			item.shootSpeed = 5f;
			item.consumable = true;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 25;
			item.shoot = ModContent.ProjectileType<Projectiles.SandBomb>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.buyPrice(0, 0, 4, 0);
			item.useAnimation = 25;
			item.height = dims.Height;
		}
	}
}