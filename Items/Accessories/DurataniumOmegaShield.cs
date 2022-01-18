using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class DurataniumOmegaShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duratanium Omega Shield");
            Tooltip.SetDefault("Increases defense and regenerates life when struck\nGreatly slows the effects of damage over time debuffs");
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
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().incDef = true;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().regenStrike = true;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().duraShield = true;
            player.noKnockback = true;
        }
    }
}
