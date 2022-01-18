using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class TropicalShroomCap : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropical Shroom Cap");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.height = dims.Height;
            item.rare = ItemRarityID.White;
            item.maxStack = 999;
            item.value = Item.buyPrice(0, 0, 1, 0);
        }
    }
}
