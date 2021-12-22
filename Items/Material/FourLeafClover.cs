using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class FourLeafClover : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Four Leaf Clover");
            Tooltip.SetDefault("You are very lucky to have found this!");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = Item.sellPrice(5);
            item.height = dims.Height;
        }
    }
}
