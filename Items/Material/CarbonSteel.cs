using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class CarbonSteel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Carbon Steel");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.maxStack = 999;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronOre, 30);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadOre, 30);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.NickelOre>(), 30);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
    }
}
