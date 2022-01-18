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
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.maxStack = 999;
            item.height = dims.Height;
        }
    }
}
