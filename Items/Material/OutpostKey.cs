using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    public class OutpostKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Outpost Key");
            Tooltip.SetDefault("Opens the Tuhrtl Outpost door");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.maxStack = 999;
            item.width = dims.Width;
            item.value = 0;
            item.height = dims.Height;
            item.rare = ItemRarityID.Lime;
        }
    }
}
