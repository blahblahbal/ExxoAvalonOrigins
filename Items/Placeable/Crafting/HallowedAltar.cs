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
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.HallowedAltar>();
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.useTime = 20;
            item.maxStack = 99;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 20;
            item.height = dims.Height;
        }
    }
}
