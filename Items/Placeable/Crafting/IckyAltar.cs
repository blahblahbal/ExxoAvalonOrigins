using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Crafting
{
    class IckyAltar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icky Altar");
            Tooltip.SetDefault("The spirit of Cthulhu guards this altar");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.EvilAltarsPlaced>();
            item.placeStyle = 2;
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.useTime = 20;
            item.maxStack = 99;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 20;
            item.height = dims.Height;
        }
    }
}
