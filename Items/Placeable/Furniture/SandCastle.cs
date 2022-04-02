using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Furniture;

class SandCastle : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sand Castle");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.SandCastle>();
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.useTime = 20;
        Item.maxStack = 99;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 20;
        Item.height = dims.Height;
    }
}