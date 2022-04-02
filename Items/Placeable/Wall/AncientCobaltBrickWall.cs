using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Wall;

public class AncientCobaltBrickWall : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ancient Cobalt Brick Wall");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.createWall = ModContent.WallType<Walls.AncientCobaltBrickWall>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(4).AddIngredient(ModContent.ItemType<Tile.Ancient.AncientCobaltBrick>()).AddTile(ModContent.TileType<Tiles.Ancient.AncientWorkbench>()).Register();
        CreateRecipe(1).AddIngredient(this, 4).AddTile(ModContent.TileType<Tiles.Ancient.AncientWorkbench>()).ReplaceResult(ModContent.ItemType<Tile.Ancient.AncientCobaltBrick>());
    }
}