using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class DewofHerbs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dew of Herbs");
            Tooltip.SetDefault("A mystical object containing an unknown force");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.maxStack = 999;
            item.height = dims.Height;
        }
    }
}
