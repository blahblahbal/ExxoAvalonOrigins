using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tokens
{
    class MechastingToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechasting Token");
            Tooltip.SetDefault("Used to make things\nGathered after Mechasting is defeated");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.rare = ItemRarityID.Yellow;
            item.maxStack = 999;
            item.value = 0;
            item.height = dims.Height;
        }
    }
}
