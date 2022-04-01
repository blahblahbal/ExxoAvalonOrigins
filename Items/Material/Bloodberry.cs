using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class Bloodberry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodberry");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.width = dims.Width;
            Item.maxStack = 999;
            Item.value = 100;
            Item.height = dims.Height;
        }
    }
}
