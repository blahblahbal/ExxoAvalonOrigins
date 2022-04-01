using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Furniture
{
    class OrangeDungeonChair : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orange Dungeon Chair");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.OrangeDungeonChair>();
            Item.width = dims.Width;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 99;
            Item.value = 200;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
    }
}
