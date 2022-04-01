using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Furniture
{
    class BookcaseTeleporter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bookcase Teleporter");
            Tooltip.SetDefault("'What a great way to hide a teleporter'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.BookcaseTeleporter>();
            Item.width = dims.Width;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 99;
            Item.value = 300;
            Item.mech = true;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
    }
}
