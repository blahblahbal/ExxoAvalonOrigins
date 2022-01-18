using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tokens
{
    class HellcastleToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellcastle Token");
            Tooltip.SetDefault("Used to make things\nGathered in the Hellcastle after Phantasm is defeated");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.rare = ItemRarityID.Cyan;
            item.maxStack = 999;
            item.value = 0;
            item.height = dims.Height;
        }
    }
}
