using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class Zircon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zircon");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.value = 4400;
            item.maxStack = 999;
            item.height = dims.Height;
        }
    }
}
