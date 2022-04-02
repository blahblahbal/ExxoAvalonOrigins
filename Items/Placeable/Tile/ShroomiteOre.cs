using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile;

class ShroomiteOre : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shroomite Ore");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.Ores.ShroomiteOre>();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.value = Item.sellPrice(0, 0, 40, 0);
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}