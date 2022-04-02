using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Crafting;

class DragonAltar : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dragon Altar");
        Tooltip.SetDefault("Used to summon the Dragon Lord");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.DragonAltar>();
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.value = 50000;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}