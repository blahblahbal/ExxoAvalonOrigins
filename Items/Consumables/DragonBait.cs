using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables;

class DragonBait : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dragon Bait");
        Tooltip.SetDefault("Vital in the creation of the Dragon Spine");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.value = 1000;
        Item.height = dims.Height;
    }
}