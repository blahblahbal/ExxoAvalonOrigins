using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class ForsakenCross : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Forsaken Cross");
        Tooltip.SetDefault("Increases damage and critical strike chance by 7% while invincible\nIncreases length of invincibility after taking damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 3, 0, 0);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.longInvince = true;
        if (player.immune)
        {
            player.GetCritChance(DamageClass.Generic) += 7;
            player.GetDamage(DamageClass.Generic) += 0.07f;
        }
    }
}
