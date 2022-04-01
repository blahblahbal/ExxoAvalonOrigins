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
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.maxStack = 100;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.height = dims.Height;
        }
    }
}
