using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class Vortex : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex");
            Tooltip.SetDefault("Immunity to On Fire!");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = 100000;
            Item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.OnFire] = true;
        }
    }
}
