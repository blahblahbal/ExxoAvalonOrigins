using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Furniture;

class VertebraeDoor : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Vertebrae Door");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.VertebraeDoorClosed>();
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.value = 200;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}