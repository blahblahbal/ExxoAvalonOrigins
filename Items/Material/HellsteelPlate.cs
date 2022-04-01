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
            Item.width = dims.Width;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(0, 0, 2);
            Item.height = dims.Height;
        }
    }
}
