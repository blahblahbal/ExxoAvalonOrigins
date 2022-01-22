using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Painting
{
    public class ACometHasStruckGround : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("A Comet Has Struck Ground");
            Tooltip.SetDefault("'B. Harold'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.rare = ItemRarityID.Green;
            item.createTile = ModContent.TileType<Tiles.Paintings>();
            item.placeStyle = 5;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
