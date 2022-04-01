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
            Item.width = dims.Width;
            Item.rare = ItemRarityID.Cyan;
            Item.maxStack = 999;
            Item.value = 0;
            Item.height = dims.Height;
        }
    }
}
