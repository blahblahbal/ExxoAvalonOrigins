using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class Pathogen : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Pathogen");
        Tooltip.SetDefault("'Blech'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.value = 4500;
        Item.height = dims.Height;
    }
}