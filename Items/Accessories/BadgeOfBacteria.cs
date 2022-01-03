using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    public class BadgeOfBacteria : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Badge of Baceria");
            Tooltip.SetDefault("Once hit the next time you are struck the attacker will take damage.");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/Accessories/BadgeOfBacteria");
            item.rare = -12;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.height = dims.Height;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().bOfBacteria = true;
        }
    }
}
