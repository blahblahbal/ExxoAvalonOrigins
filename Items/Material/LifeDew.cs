using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class LifeDew : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Dew");
            Tooltip.SetDefault("'The essence of living creatures'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = 400000;
            item.height = dims.Height;
        }
    }
}
