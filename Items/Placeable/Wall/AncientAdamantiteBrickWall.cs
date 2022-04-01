using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Wall
{
    public class AncientAdamantiteBrickWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Adamantite Brick Wall");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.width = dims.Width;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.createWall = ModContent.WallType<Walls.AncientAdamantiteBrickWall>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }

        public override void AddRecipes()
        {
            CreateRecipe(4).AddIngredient(ModContent.ItemType<Tile.Ancient.AncientAdamantiteBrick>()).AddTile(ModContent.TileType<Tiles.Ancient.AncientWorkbench>()).Register();
            CreateRecipe(1).AddIngredient(this, 4).AddTile(ModContent.TileType<Tiles.Ancient.AncientWorkbench>()).ReplaceResult(ModContent.ItemType<Tile.Ancient.AncientAdamantiteBrick>());
        }
    }
}
