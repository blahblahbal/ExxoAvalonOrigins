using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class EtherealHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ethereal Heart");
            Tooltip.SetDefault("Grants a 10% chance for enemies to drop a platinum heart");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().ethHeart = true;
        }
    }
}
