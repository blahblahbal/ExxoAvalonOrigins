using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile;

class HallowBomb : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hallow Bomb");
        Tooltip.SetDefault("Converts tiles to the Hallow in a large radius");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.maxStack = 999;
        Item.mech = true;
        Item.createTile = ModContent.TileType<Tiles.BiomeBombs>();
        Item.placeStyle = 6;
        Item.consumable = true;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}