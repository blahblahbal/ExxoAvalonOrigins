using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class VenomShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Venom Shard");
            Tooltip.SetDefault("'A fragment of venomous creatures'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.Shards>();
            item.placeStyle = 2;
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 0, 12, 0);
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
