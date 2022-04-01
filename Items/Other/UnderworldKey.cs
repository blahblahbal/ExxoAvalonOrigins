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
            Item.rare = ItemRarityID.Purple;
            Item.width = dims.Width;
            Item.maxStack = 999;
            Item.height = dims.Height;
        }
    }
}
