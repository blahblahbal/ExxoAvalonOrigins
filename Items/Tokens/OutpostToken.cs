using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tokens
{
    class OutpostToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tuhrtl Outpost Token");
            Tooltip.SetDefault("Used to make things\nGathered in the Tuhrtl Outpost");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.rare = ItemRarityID.Blue;
            item.maxStack = 999;
            item.value = 0;
            item.height = dims.Height;
        }
    }
}
