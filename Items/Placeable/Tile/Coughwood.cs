using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class Coughwood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coughwood");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.Coughwood>();
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.scale = 1f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 999;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
