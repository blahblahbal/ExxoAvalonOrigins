using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Other;

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
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.height = dims.Height;
    }
}