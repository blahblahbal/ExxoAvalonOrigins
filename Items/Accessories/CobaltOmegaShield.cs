using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class CobaltOmegaShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cobalt Omega Shield");
            Tooltip.SetDefault("Greatly increases defense and regenerates life when struck\nSlows the effects of damage over time debuffs");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 4;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.value = 100000;
            item.accessory = true;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().incDef = true;
            player.Avalon().regenStrike = true;
            player.Avalon().duraShield = true;
            player.Avalon().cOmega = true;
            player.noKnockback = true;
            player.Avalon().spikeImmune = true;
        }
    }
}
