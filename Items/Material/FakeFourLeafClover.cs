using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class FakeFourLeafClover : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fake Four Leaf Clover");
            Tooltip.SetDefault("Aww... it's fake!");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 30);
            item.height = dims.Height;
        }
    }
}
