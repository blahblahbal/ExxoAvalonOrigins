using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile;

class CorruptionBomb : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Corruption Bomb");
        Tooltip.SetDefault("Converts tiles to the Corruption in a large radius");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.maxStack = 999;
        Item.mech = true;
        Item.createTile = ModContent.TileType<Tiles.BiomeBombs>();
        Item.placeStyle = 1;
        Item.consumable = true;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}