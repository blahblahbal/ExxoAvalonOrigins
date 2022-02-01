using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    public class BadgeOfBacteria : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Badge of Bacteria");
            Tooltip.SetDefault("Increases damage by 8 after being hit\nAttackers also take damage for a short time after you are hit");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Items/Accessories/BadgeOfBacteria");
            item.rare = 2;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.height = dims.Height;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().bOfBacteria = true;
        }
    }
}
