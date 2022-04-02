using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Crafting;

class VertebraeWorkBench : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Vertebrae Work Bench");
        Tooltip.SetDefault("Used for basic crafting");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.VertebraeWorkbench>();
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.value = 150;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}