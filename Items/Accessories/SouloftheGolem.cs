using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class SouloftheGolem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of the Golem");
            Tooltip.SetDefault("Grants a 15% chance for enemies to drop a platinum heart");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ethHeart = true;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().heartGolem = true;
        }
    }
}
