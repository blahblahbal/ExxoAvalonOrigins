using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Crafting
{
    class HallowedAltar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Altar");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.HallowedAltar>();
            Item.rare = ItemRarityID.Pink;
            Item.width = dims.Width;
            Item.useTime = 20;
            Item.maxStack = 99;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.height = dims.Height;
        }
    }
}
