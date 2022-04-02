using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile;

class MintChocolateCandyCaneBlock : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Mint Chocolate Candy Cane Block");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.MintChocCandyCane>();
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
        CreateRecipe(2).AddIngredient(ItemID.GreenCandyCaneBlock).AddIngredient(ModContent.ItemType<ChocolateCandyCaneBlock>()).AddTile(TileID.WorkBenches).Register();
    }
}