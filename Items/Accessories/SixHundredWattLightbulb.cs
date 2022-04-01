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
            Item.rare = ItemRarityID.LightPurple;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = 100000;
            Item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Blackout] = true;
        }
    }
}
