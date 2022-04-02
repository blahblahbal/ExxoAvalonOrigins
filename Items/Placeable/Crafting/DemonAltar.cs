using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Crafting;

class DemonAltar : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Demon Altar");
        Tooltip.SetDefault("The spirit of Cthulhu guards this altar");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = Item.autoReuse = true;
        Item.createTile = ModContent.TileType<Tiles.EvilAltarsPlaced>();
        Item.placeStyle = 0;
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.useTime = 20;
        Item.maxStack = 99;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 20;
        Item.height = dims.Height;
    }
}