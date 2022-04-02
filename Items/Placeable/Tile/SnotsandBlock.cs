using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile;

class SnotsandBlock : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Snotsand Block");
        Tooltip.SetDefault("'Disgustingly sticky'");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.Snotsand>();
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.scale = 1f;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}