using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class Magnet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magnet");
            Tooltip.SetDefault("Doubles item grab range");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Pink;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = 150000;
            Item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().magnet = true;
        }
    }
}
