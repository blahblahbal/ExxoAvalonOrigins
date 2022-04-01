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
            Item.rare = 2;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.height = dims.Height;
            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().bOfBacteria = true;
        }
    }
}
