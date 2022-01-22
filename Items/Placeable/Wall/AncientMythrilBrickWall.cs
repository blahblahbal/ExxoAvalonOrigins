using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Wall
{
    public class AncientMythrilBrickWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Mythril Brick Wall");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.createWall = ModContent.WallType<Walls.AncientMythrilBrickWall>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 999;
            item.useAnimation = 15;
            item.height = dims.Height;
        }

        public override void AddRecipes()
        {
            var r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Items.Placeable.Tile.AncientMythrilBrick>());
            r.AddTile(ModContent.TileType<Tiles.AncientWorkbench>());
            r.SetResult(this, 4);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(this, 4);
            r.AddTile(ModContent.TileType<Tiles.AncientWorkbench>());
            r.SetResult(ModContent.ItemType<Items.Placeable.Tile.AncientMythrilBrick>());
            r.AddRecipe();
        }
    }
}
