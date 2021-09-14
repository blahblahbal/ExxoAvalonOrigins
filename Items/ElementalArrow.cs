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
	class ElementalArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Arrow");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/ElementalArrow");
			item.damage = 17;
			item.shootSpeed = 3.5f;
			item.ammo = AmmoID.Arrow;
			item.ranged = true;
			item.consumable = true;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.knockBack = 5f;
			item.shoot = ModContent.ProjectileType<Projectiles.ElementalArrow>();
			item.value = Item.sellPrice(0, 0, 3, 0);
			item.maxStack = 2000;
			item.height = dims.Height;
		}
	}
}