using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tokens
{
    class ContagionToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Contagion Token");
            Tooltip.SetDefault("Used to make things\nGathered in the Contagion, having defeated a boss");
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
