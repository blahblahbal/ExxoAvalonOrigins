using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Throw
{
	class EnchantedShuriken : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Shuriken");
		}
		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 13;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.shootSpeed = 9f;
			item.ranged = true;
			item.consumable = true;
			item.rare = ItemRarityID.Green;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 15;
			item.shoot = ModContent.ProjectileType<Projectiles.EnchantedShuriken>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 30;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}
