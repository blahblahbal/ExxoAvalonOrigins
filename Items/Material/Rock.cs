using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class Rock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rock");
            Tooltip.SetDefault("Used for crafting the Eye of Oblivion");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = 0;
            item.height = dims.Height;
        }
    }
}
