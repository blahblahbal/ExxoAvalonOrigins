using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class ChaosDust : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Dust");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.value = 5000;
            Item.maxStack = 999;
            Item.height = dims.Height;
        }
    }
}
