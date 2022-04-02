using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile;

class Peridot : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Peridot");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.maxStack = 999;
        Item.createTile = ModContent.TileType<Tiles.PlacedGems>();
        Item.placeStyle = 4;
        Item.consumable = true;
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.useTime = 10;
        Item.value = 4000;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}