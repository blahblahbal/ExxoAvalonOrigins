using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class BlahsHeadguard : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blah's Headguard");
        Tooltip.SetDefault("35% increased damage\n11% increased critical strike chance");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 100;
        Item.rare = 11;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().avalonRarity = AvalonRarity.Rainbow;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(2, 0, 0, 0);
        Item.height = dims.Height;
    }
    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<BlahsHauberk>() && legs.type == ModContent.ItemType<BlahsCuisses2>();
    }

    public override void UpdateArmorSet(Player player)
    {
        player.Avalon().blahArmor = true;
        player.setBonus = "Melee Stealth, Ranged Stealth, Attackers also take double full damage, and Spectre Heal";
        player.Avalon().meleeStealth = true;
        player.shroomiteStealth = true;
        player.Avalon().doubleDamage = true;
        player.ghostHeal = true;
        //player.thorns = true;
        player.Avalon().ghostSilence = true;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Melee) += 0.35f;
        player.GetDamage(DamageClass.Magic) += 0.35f;
        player.GetDamage(DamageClass.Ranged) += 0.35f;
        player.GetCritChance(DamageClass.Melee) += 11;
        player.GetCritChance(DamageClass.Ranged) += 11;
        player.GetCritChance(DamageClass.Magic) += 11;
    }
}