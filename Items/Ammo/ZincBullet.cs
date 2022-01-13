using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class ZincBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zinc Bullet");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.shootSpeed = 3.75f;
			item.damage = 11;
			item.ammo = AmmoID.Bullet;
			item.ranged = true;
			item.consumable = true;
			item.width = dims.Width;
			item.knockBack = 3f;
			item.shoot = ProjectileID.Bullet;
			item.maxStack = 2000;
			item.value = 15;
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 70);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.ZincBar>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 70);
            recipe.AddRecipe();
        }
    }
}
