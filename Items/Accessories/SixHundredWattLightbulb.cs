using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class SixHundredWattLightbulb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("600 Watt Lightbulb");
            Tooltip.SetDefault("Immunity to Blackout");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.LightPurple;
            item.width = dims.Width;
            item.accessory = true;
            item.value = 100000;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Blackout] = true;
        }
    }
}
