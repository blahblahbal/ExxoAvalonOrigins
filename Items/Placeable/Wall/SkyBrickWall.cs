using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Wall
{
    class SkyBrickWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sky Brick Wall");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.width = dims.Width;
            Item.useTurn = true;
            Item.useTime = 7;
            Item.createWall = ModContent.WallType<Walls.SkyBrickWallUnsafe>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(4).AddIngredient(ModContent.ItemType<Tile.SkyBrick>()).AddTile(TileID.WorkBenches).Register();
            CreateRecipe(1).AddIngredient(this, 4).AddTile(TileID.WorkBenches).ReplaceResult(ModContent.ItemType<Tile.SkyBrick>());
        }
    }
}
