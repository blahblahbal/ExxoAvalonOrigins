using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class PalladiumShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Palladium Shield");
            Tooltip.SetDefault("Regenerates health when struck");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 2;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.value = 54000;
            item.accessory = true;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().regenStrike = true;
            player.Avalon().spikeImmune = true;
        }
    }
}
