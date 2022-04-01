using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class FrigidShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frigid Shard");
            Tooltip.SetDefault("'A fragment of icy creatures'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.Shards>();
            Item.placeStyle = 1;
            Item.rare = ItemRarityID.Pink;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 0, 12, 0);
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
    }
}
