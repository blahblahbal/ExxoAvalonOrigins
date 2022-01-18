using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class VictoryPiece : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Victory Piece");
            Tooltip.SetDefault("Victory is yours!");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.maxStack = 100;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.height = dims.Height;
        }
    }
}
