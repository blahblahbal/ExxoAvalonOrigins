using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed
{
    class LargeMoonglowSeed : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Large Moonglow Seed");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.LargeHerbsStage1>();
            Item.placeStyle = 1;
            Item.width = dims.Width;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
    }
}
