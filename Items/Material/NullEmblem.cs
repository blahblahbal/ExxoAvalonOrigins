using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class NullEmblem : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Null Emblem");
        Tooltip.SetDefault("Craft it into a Wall of Flesh Emblem");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.value = Item.sellPrice(0, 1, 0, 0);
        Item.height = dims.Height;
    }
}