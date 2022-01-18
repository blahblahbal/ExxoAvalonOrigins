using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class DullingTalisman : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dulling Talisman");
            Tooltip.SetDefault("Provides life regeneration");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.lifeRegen = 2;
            item.defense = 10;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 1, 63, 0);
            item.accessory = true;
            item.height = dims.Height;
        }
    }
}
