using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Furniture
{
    class Jukebox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jukebox");
            Tooltip.SetDefault("Used to play tunes");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.Jukebox>();
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 99;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
    }
}
