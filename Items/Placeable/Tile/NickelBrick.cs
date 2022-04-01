using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class NickelBrick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Brick");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.NickelBrick>();
            Item.rare = ItemRarityID.White;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
            Item.value = 0;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
    }
}
