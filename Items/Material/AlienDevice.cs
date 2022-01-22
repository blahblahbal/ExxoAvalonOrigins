using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    public class AlienDevice : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Alien Device");
            Tooltip.SetDefault("Used for crafting the Eye of Oblivion");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = 0;
            item.height = dims.Height;
        }
    }
}
