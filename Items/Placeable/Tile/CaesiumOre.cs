using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile;

class CaesiumOre : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Caesium Ore");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.Ores.CaesiumOre>();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.useTime = 10;
        Item.useTurn = true;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.value = Item.sellPrice(0, 0, 21, 0);
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}