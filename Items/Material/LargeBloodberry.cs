using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class LargeBloodberry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Large Bloodberry");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.LargeHerbsStage4>();
            Item.placeStyle = 7;
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
