using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Other
{
    class UnderworldKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Underworld Key");
            Tooltip.SetDefault("Unlocks an Underworld Chest in the dungeon");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Purple;
            item.width = dims.Width;
            item.maxStack = 999;
            item.height = dims.Height;
        }
    }
}
