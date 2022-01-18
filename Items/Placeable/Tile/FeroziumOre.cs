using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class FeroziumOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ferozium Ore");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.Ores.FeroziumOre>();
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.useTime = 10;
            item.useTurn = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 75);
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
