using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class SolarFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Fragment");
            Tooltip.SetDefault("'Hot!'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.value = 10;
            item.maxStack = 999;
            item.height = dims.Height;
        }
    }
}
