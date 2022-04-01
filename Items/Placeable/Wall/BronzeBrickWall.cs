using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Wall
{
    class BronzeBrickWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Brick Wall");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.width = dims.Width;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.createWall = ModContent.WallType<Walls.BronzeBrickWall>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(4).AddIngredient(ModContent.ItemType<Tile.BronzeBrick>()).AddTile(TileID.WorkBenches).Register();
            CreateRecipe(1).AddIngredient(this, 4).AddTile(TileID.WorkBenches).ReplaceResult(ModContent.ItemType<Tile.BronzeBrick>());
        }
    }
}
