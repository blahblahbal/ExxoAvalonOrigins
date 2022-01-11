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
            item.autoReuse = true;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.PlacedBars>();
            item.placeStyle = 17;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.useTime = 10;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<OblivionBar>());
            r.AddIngredient(ModContent.ItemType<UnvolanditeBar>());
            r.AddIngredient(ModContent.ItemType<Material.DarkMatterGel>(), 3);
            r.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<OblivionBar>());
            r.AddIngredient(ModContent.ItemType<VorazylcumBar>());
            r.AddIngredient(ModContent.ItemType<Material.DarkMatterGel>(), 3);
            r.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
