using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Storage;

class ContagionChest : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Contagion Chest");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1f;
        Item.maxStack = 99;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.ContagionChest>();
        Item.width = dims.Width;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 0, 2, 0);
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}