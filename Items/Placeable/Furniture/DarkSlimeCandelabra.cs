using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Furniture
{
    class DarkSlimeCandelabra : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Slime Candelabra");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.DarkSlimeCandelabra>();
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.value = 1500;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
