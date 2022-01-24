using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile.Ancient
{
    public class AncientCopperBrick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Copper Brick");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.Ancient.AncientCopperBrick>();
            item.width = dims.Width;
            item.useTime = 10;
            item.useTurn = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 999;
            item.useAnimation = 15;
            item.height = dims.Height;
        }

        public override void AddRecipes()
        {
            var r = new ModRecipe(mod);
            r.AddIngredient(ItemID.CopperBrick);
            r.AddTile(ModContent.TileType<Tiles.Ancient.AncientWorkbench>());
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(this);
            r.AddTile(ModContent.TileType<Tiles.Ancient.AncientWorkbench>());
            r.SetResult(ItemID.CopperBrick);
            r.AddRecipe();
        }
    }
}
