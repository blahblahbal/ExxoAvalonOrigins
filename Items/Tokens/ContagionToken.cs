using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tokens;

class ContagionToken : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Contagion Token");
        Tooltip.SetDefault("Used to make things\nGathered in the Contagion, having defeated a boss");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.rare = ItemRarityID.Blue;
        Item.maxStack = 999;
        Item.value = 0;
        Item.height = dims.Height;
    }
}