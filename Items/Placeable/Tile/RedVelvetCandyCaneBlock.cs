using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile;

class RedVelvetCandyCaneBlock : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Red Velvet Candy Cane Block");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.RedVelCandyCane>();
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }

    public override void AddRecipes()
    {
        CreateRecipe(2).AddIngredient(ItemID.CandyCaneBlock).AddIngredient(ModContent.ItemType<ChocolateCandyCaneBlock>()).AddTile(TileID.WorkBenches).Register();
    }
}