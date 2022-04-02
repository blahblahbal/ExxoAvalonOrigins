using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Fish;

class Ickfish : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ickfish");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.value = 10;
        Item.maxStack = 999;
        Item.height = dims.Height;
    }
}