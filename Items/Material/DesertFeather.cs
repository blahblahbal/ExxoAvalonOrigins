using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class DesertFeather : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Feather");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.maxStack = 999;
            item.height = dims.Height;
        }
    }
}
