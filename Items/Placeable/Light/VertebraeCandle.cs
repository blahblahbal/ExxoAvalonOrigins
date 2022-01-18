using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Light
{
    class VertebraeCandle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vertebrae Candle");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.noWet = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.VertebraeCandle>();
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
