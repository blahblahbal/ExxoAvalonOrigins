using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class ContaminatedMushroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Virulent Mushroom");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = 50;
            item.height = dims.Height;
        }
    }
}
