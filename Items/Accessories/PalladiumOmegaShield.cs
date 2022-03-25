using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class PalladiumOmegaShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Palladium Omega Shield");
            Tooltip.SetDefault("Quickly regenerates life and increases defense when struck\nSlows the effects of damage over time debuffs");
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
            player.Avalon().pOmega = true;
            player.noKnockback = true;
            player.Avalon().spikeImmune = true;
        }
    }
}
