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
            Item.rare = ItemRarityID.Lime;
            Item.width = dims.Width;
            Item.value = 10;
            Item.maxStack = 999;
            Item.height = dims.Height;
        }
    }
}
