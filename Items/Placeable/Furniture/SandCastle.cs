using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Furniture
{
    class SandCastle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sand Castle");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.SandCastle>();
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.useTime = 20;
            item.maxStack = 99;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 20;
            item.height = dims.Height;
        }
    }
}
