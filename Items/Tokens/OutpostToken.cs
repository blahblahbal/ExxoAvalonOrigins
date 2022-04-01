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
            Item.width = dims.Width;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 999;
            Item.value = 0;
            Item.height = dims.Height;
        }
    }
}
