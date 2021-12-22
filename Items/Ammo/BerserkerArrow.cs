using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class BerserkerArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Berserker Arrow");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 19;
			item.shootSpeed = 4f;
			item.ammo = AmmoID.Arrow;
			item.ranged = true;
			item.consumable = true;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.knockBack = 4f;
			item.shoot = ModContent.ProjectileType<Projectiles.BerserkerArrow>();
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.maxStack = 2000;
			item.height = dims.Height;
		}
	}
}
