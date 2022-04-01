using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class SolariumRod : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solarium Rod");
            Tooltip.SetDefault("Used at the Solarium Shrine");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.consumable = true;
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.maxStack = 100;
            Item.height = dims.Height;
        }
    }
}
