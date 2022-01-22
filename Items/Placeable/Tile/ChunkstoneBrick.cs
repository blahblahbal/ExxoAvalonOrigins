using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    public class ChunkstoneBrick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chunkstone Brick");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.createTile = ModContent.TileType<Tiles.ChunkstoneBrick>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 999;
            item.useAnimation = 15;
            item.height = dims.Height;
        }

        public override void AddRecipes()
        {
            var r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<ChunkstoneBlock>());
            r.AddIngredient(ItemID.StoneBlock);
            r.AddTile(TileID.Furnaces);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Items.Placeable.Wall.ChunkstoneBrickWall>(), 4);
            r.AddTile(TileID.WorkBenches);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
