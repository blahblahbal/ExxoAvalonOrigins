using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class TorrentShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Torrent Shard");
            Tooltip.SetDefault("'A fragment of water creatures'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.Shards>();
            Item.placeStyle = 6;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 0, 12, 0);
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.WaterShard>(), 2).AddIngredient(ItemID.WaterBucket).AddTile(TileID.MythrilAnvil).Register();
        }
    }
}
