using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class BandofStamina : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Band of Stamina");
            Tooltip.SetDefault("Increases maximum stamina by 60");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.accessory = true;
            item.value = 50000;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().statStamMax2 += 60;
        }
    }
}
