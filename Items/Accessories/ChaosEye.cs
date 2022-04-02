using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class ChaosEye : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Chaos Eye");
        Tooltip.SetDefault("Critical strike chance increases as your health drops\n8% increased critical strike chance");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.value = 3450000;
        Item.accessory = true;
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().chaosCharm = true;
        player.GetCritChance(DamageClass.Melee) += 8;
        player.GetCritChance(DamageClass.Ranged) += 8;
        player.GetCritChance(DamageClass.Magic) += 8;
        player.GetCritChance(DamageClass.Throwing) += 8;
    }
}