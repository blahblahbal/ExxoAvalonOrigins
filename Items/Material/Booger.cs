using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class Booger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Booger");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = 750;
            item.height = dims.Height;
        }
    }
}
