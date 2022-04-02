using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile;

class Starstone : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Starstone");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.Ores.Starstone>();
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.useTime = 10;
        Item.useTurn = true;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.value = Item.sellPrice(0, 0, 2, 0);
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(this, 60).AddTile(TileID.Furnaces).ReplaceResult(ItemID.ManaCrystal);
        CreateRecipe(60).AddIngredient(ItemID.ManaCrystal).AddTile(TileID.Furnaces).Register();
        CreateRecipe(1).AddIngredient(this, 20).AddTile(TileID.Furnaces).ReplaceResult(ItemID.FallenStar);
    }
}