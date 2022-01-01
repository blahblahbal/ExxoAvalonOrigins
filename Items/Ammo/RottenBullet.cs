using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class RottenBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rotten Bullet");
			Tooltip.SetDefault("Slow speed, low range, but high damage and knockback");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 15;
			item.shootSpeed = 1.5f;
			item.ammo = AmmoID.Bullet;
			item.ranged = true;
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.knockBack = 16f;
			item.shoot = ModContent.ProjectileType<Projectiles.RottenBullet>();
			item.value = 10;
			item.maxStack = 2000;
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 25);
            recipe.AddIngredient(ModContent.ItemType<Material.RottenEye>(), 5);
            recipe.AddIngredient(ItemID.CursedFlame);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 25);
            recipe.AddRecipe();
        }
    }
}
