using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class YuckyBit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yucky Bit");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = 750;
            item.height = dims.Height;
        }
    }
}
