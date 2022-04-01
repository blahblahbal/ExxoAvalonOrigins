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
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.PlacedBars>();
            Item.placeStyle = 15;
            Item.rare = ItemRarityID.Red;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.value = Item.sellPrice(0, 1, 30, 0);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<PyroscoricBar>()).AddIngredient(ModContent.ItemType<HydrolythBar>()).AddIngredient(ModContent.ItemType<BerserkerBar>()).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<TritanoriumBar>()).AddIngredient(ModContent.ItemType<HydrolythBar>()).AddIngredient(ModContent.ItemType<BerserkerBar>()).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        }
    }
}
