using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class Boltstone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boltstone");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.Ores.Boltstone>();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.useTime = 10;
            item.useTurn = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 50);
            item.useAnimation = 15;
            item.height = dims.Height;
        }

        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(this, 35);
            r.AddTile(TileID.Furnaces);
            r.SetResult(ModContent.ItemType<Items.Consumables.StaminaCrystal>());
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Items.Consumables.StaminaCrystal>());
            r.AddTile(TileID.Furnaces);
            r.SetResult(this, 35);
            r.AddRecipe();
        }
    }
}
