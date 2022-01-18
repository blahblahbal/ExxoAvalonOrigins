using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class GreekExtinguisher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Greek Extinguisher");
            Tooltip.SetDefault("Immunity to Cursed Inferno");
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
            player.buffImmune[BuffID.CursedInferno] = true;
        }
    }
}
