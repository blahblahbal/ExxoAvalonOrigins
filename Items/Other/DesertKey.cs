using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Other
{
    class DesertKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Key");
            Tooltip.SetDefault("Unlocks a Desert Chest in the dungeon");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.maxStack = 999;
            item.height = dims.Height;
        }
    }
}
