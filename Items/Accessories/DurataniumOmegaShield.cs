using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

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
        Item.defense = 4;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.value = 100000;
        Item.accessory = true;
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().incDef = true;
        player.Avalon().regenStrike = true;
        player.Avalon().duraShield = true;
        player.noKnockback = true;
        player.Avalon().spikeImmune = true;
    }
}