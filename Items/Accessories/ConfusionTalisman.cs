using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class ConfusionTalisman : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Confusion Talisman");
            Tooltip.SetDefault("12% chance for your attacks to confuse your enemies");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().confusionTal = true; //unimplemented
        }
    }
}
