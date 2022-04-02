using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class YuckyBit : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Yucky Bit");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.value = 750;
        Item.height = dims.Height;
    }
}