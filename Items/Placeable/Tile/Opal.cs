using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class Opal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Opal");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.maxStack = 999;
            Item.createTile = ModContent.TileType<Tiles.PlacedGems>();
            Item.placeStyle = 0;
            Item.consumable = true;
            Item.rare = 11;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
    }
}
