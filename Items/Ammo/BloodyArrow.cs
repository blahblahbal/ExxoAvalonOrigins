using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class BloodyArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloody Arrow");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 10;
			item.shootSpeed = 3.4f;
			item.ammo = AmmoID.Arrow;
			item.ranged = true;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.knockBack = 3f;
			item.shoot = ModContent.ProjectileType<Projectiles.BloodyArrow>();
			item.value = Item.sellPrice(0, 0, 0, 8);
			item.maxStack = 2000;
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 5);
            recipe.AddIngredient(ModContent.ItemType<Material.Patella>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}
