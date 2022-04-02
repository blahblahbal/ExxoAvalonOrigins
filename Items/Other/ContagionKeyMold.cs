using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Other;

class ContagionKeyMold : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Contagion Key Mold");
        Tooltip.SetDefault("Used for crafting a Contagion Key");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.scale = 1f;
        Item.maxStack = 999;
        Item.height = dims.Height;
    }
}