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
	class MagicGrenade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Grenade");
			Tooltip.SetDefault("A small explosion that will not destroy tiles");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/MagicGrenade");
			item.magic = true;
			item.damage = 85;
			item.noUseGraphic = true;
			item.shootSpeed = 8f;
			item.mana = 40;
			item.rare = ItemRarityID.Cyan;
			item.noMelee = true;
			item.width = dims.Width;
			item.knockBack = 8f;
			item.useTime = 27;
			item.shoot = ModContent.ProjectileType<Projectiles.MagicGrenade>();
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 27;
			item.height = dims.Height;
		}
	}
}