using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Crafting
{
    class HerbologyBench : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Herbology Bench");
            Tooltip.SetDefault("Used for herb-related exchange");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.HerbologyBench>();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 0, 20);
            item.useAnimation = 15;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 8);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 45);
            recipe.AddIngredient(ItemID.GrassSeeds, 20);
            recipe.AddRecipeGroup("ExxoAvalonOrigins:Herbs", 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
