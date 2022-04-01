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
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.EvilAltarsPlaced>();
            Item.placeStyle = 2;
            Item.rare = ItemRarityID.Blue;
            Item.width = dims.Width;
            Item.useTime = 20;
            Item.maxStack = 99;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.height = dims.Height;
        }
    }
}
