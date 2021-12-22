using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class SceneofCarnage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scene of Carnage");
			Tooltip.SetDefault("Tome\n15% increased melee damage and speed");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 0, 40);
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeSpeed += 0.15f;
            player.meleeDamage += 0.15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<BerserkerBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 30);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 100);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
