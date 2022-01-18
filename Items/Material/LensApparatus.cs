using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class LensApparatus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lens Apparatus");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.height = dims.Height;
        }
    }
}
