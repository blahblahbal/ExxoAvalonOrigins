using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class NullEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Null Emblem");
            Tooltip.SetDefault("Craft it into a Wall of Flesh Emblem");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.height = dims.Height;
        }
    }
}
