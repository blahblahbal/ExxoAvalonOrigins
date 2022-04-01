using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Fish
{
    class SicklyTrout : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sickly Trout");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.White;
            Item.width = dims.Width;
            Item.value = 10;
            Item.maxStack = 999;
            Item.height = dims.Height;
        }
    }
}
