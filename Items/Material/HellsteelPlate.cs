using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class HellsteelPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellsteel Plate");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 2);
            item.height = dims.Height;
        }
    }
}
