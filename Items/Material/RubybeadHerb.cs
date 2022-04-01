using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class RubybeadHerb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rubybead Herb");
            Tooltip.SetDefault("A mystical object containing an unknown force");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.maxStack = 999;
            Item.height = dims.Height;
        }
    }
}
