using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Furniture
{
    class OrangeDungeonBed : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orange Bed");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.OrangeDungeonBed>();
            Item.width = dims.Width;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 99;
            Item.value = 2000;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
    }
}
