using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class EarthShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earth Shard");
            Tooltip.SetDefault("'A fragment of earthen creatures'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 6, 0);
            item.height = dims.Height;
        }
    }
}
