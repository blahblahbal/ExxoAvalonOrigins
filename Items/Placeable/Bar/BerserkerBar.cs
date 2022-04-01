using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Bar
{
    class BerserkerBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Bar");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.PlacedBars>();
            Item.placeStyle = 17;
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<OblivionBar>()).AddIngredient(ModContent.ItemType<UnvolanditeBar>()).AddIngredient(ModContent.ItemType<Material.DarkMatterGel>(), 3).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<OblivionBar>()).AddIngredient(ModContent.ItemType<VorazylcumBar>()).AddIngredient(ModContent.ItemType<Material.DarkMatterGel>(), 3).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        }
    }
}
