using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class SolariumStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solarium Star");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.maxStack = 999;
            Item.height = dims.Height;
        }
    }
}
