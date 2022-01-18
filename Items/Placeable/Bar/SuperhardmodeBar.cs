using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Bar
{
    class SuperhardmodeBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Superhardmode Bar");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.PlacedBars>();
            item.placeStyle = 15;
            item.rare = ItemRarityID.Purple;
            item.width = dims.Width;
            item.useTime = 10;
            item.value = Item.sellPrice(0, 1, 30, 0);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PyroscoricBar>());
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>());
            recipe.AddIngredient(ModContent.ItemType<BerserkerBar>());
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TritanoriumBar>());
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>());
            recipe.AddIngredient(ModContent.ItemType<BerserkerBar>());
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
