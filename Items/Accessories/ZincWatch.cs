using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class ZincWatch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Watch");
            Tooltip.SetDefault("Tells the time");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.SilverWatch);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.accWatch < 1) player.accWatch = 1;
        }

        public override void UpdateInventory(Player player)
        {
            if (player.accWatch < 1) player.accWatch = 1;
        }
    }
}
