using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Light;

class BismuthCandelabra : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bismuth Candelabra");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Items/Placeable/Light/BismuthCandelabra");
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.BismuthCandelabra>();
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.value = 1500;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}