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
            item.consumable = true;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.maxStack = 100;
            item.height = dims.Height;
        }
    }
}
