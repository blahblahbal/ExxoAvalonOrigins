using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Fish
{
    class Ickfish : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ickfish");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.value = 10;
            item.maxStack = 999;
            item.height = dims.Height;
        }
    }
}
