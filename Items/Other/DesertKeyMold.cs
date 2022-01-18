using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Other
{
    class DesertKeyMold : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Key Mold");
            Tooltip.SetDefault("Used for crafting a Desert Key");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.maxStack = 999;
            item.height = dims.Height;
        }
    }
}
