using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class Beak : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beak");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.Beak>();
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.maxStack = 999;
            Item.value = 50;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
    }
}
