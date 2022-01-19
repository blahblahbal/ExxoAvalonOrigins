﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
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
            item.defense = 100;
            item.rare = 11;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().avalonRarity = AvalonRarity.Rainbow;
            item.width = dims.Width;
            item.value = Item.sellPrice(2, 0, 0, 0);
            item.height = dims.Height;
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
            player.meleeDamage += 0.35f;
            player.magicDamage += 0.35f;
            player.rangedDamage += 0.35f;
            player.meleeCrit += 11;
            player.rangedCrit += 11;
            player.magicCrit += 11;
        }
    }
}
