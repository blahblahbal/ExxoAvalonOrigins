using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Painting;

class FightoftheBumblebee : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Fight of the Bumblebee");
        Tooltip.SetDefault("'Dan D. Lyon'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.rare = ItemRarityID.Orange;
        Item.createTile = ModContent.TileType<Tiles.Paintings>();
        Item.placeStyle = 7;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.value = Item.sellPrice(0, 0, 10, 0);
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}