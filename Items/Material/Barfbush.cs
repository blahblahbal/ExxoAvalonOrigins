using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class Barfbush : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Barfbush");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.value = 100;
        Item.height = dims.Height;
    }
}