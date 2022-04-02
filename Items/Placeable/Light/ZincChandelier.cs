using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Light;

class ZincChandelier : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Zinc Chandelier");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Items/Placeable/Light/ZincChandelier");
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.ZincChandelier>();
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.value = 15000;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}