using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class GhostintheMachine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ghost in the Machine");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.height = dims.Height;
        }
    }
}
