using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class MusicBoxEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Music Box Essence");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.height = dims.Height;
        }
    }
}
