using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Wall;

class BlueLihzahrdBrickWall : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blue Lihzahrd Brick Wall");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        //item.createWall = ModContent.WallType<Walls.BlueLihzahrdBrick>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(4).AddIngredient(ModContent.ItemType<Tile.BlueLihzahrdBrick>()).AddTile(TileID.WorkBenches).Register();
        CreateRecipe(1).AddIngredient(this, 4).AddTile(TileID.WorkBenches).ReplaceResult(ModContent.ItemType<Tile.BlueLihzahrdBrick>());
    }
}