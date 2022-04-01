using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tokens
{
    class MechastingToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Post-Mechasting Token");
            Tooltip.SetDefault("Used to make things\nGathered after Mechasting is defeated");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.width = dims.Width;
            Item.rare = ItemRarityID.Yellow;
            Item.maxStack = 999;
            Item.value = 0;
            Item.height = dims.Height;
        }
    }
}
