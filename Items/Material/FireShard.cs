using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class FireShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Shard");
            Tooltip.SetDefault("'A fragment of fiery creatures'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(0, 0, 6, 0);
            Item.height = dims.Height;
        }
    }
}
