using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class CrystalSeed : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Seed");
			Tooltip.SetDefault("For use with Blowpipes");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 5;
			item.ammo = AmmoID.Dart;
			item.ranged = true;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.shoot = ModContent.ProjectileType<Projectiles.CrystalSeed>();
			item.maxStack = 999;
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Seed, 50);
            recipe.AddIngredient(ItemID.CrystalShard);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}
