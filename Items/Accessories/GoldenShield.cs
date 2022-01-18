using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class GoldenShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Shield");
            Tooltip.SetDefault("Immunity to Ichor");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.accessory = true;
            item.value = 100000;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Ichor] = true;
        }
    }
}
