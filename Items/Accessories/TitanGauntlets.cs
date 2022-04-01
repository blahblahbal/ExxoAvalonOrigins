using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    [AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]
    class TitanGauntlets : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titan Gauntlets");
            Tooltip.SetDefault("Attacks inflict Frostburn, increases damage and melee speed by 9%, reduces team member damage (only active above 25% HP)\nIncreases knockback, reduces dmg when below 25% HP, [+15 defense, +3 life regeneration, +15% damage] (Only when below 33% HP)");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 14;
            Item.rare = 11;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 30, 0, 0);
            Item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.statLife <= player.statLifeMax2 * 0.25)
            {
                player.AddBuff(62, 5, true);
            }
            player.frostBurn = true;
            player.kbGlove = true;
            player.meleeSpeed += 0.1f;
            player.GetDamage(DamageClass.Melee) += 0.1f;
            player.GetDamage(DamageClass.Ranged) += 0.1f;
            player.frostArmor = true;
            if (player.statLife <= player.statLifeMax2 * 0.33)
            {
                player.statDefense += 20;
                player.lifeRegen += 5;
                player.GetDamage(DamageClass.Magic) += 0.2f;
                player.GetDamage(DamageClass.Melee) += 0.2f;
                player.GetDamage(DamageClass.Summon) += 0.2f;
                player.GetDamage(DamageClass.Ranged) += 0.2f;
            }
            player.noKnockback = true;
            if (player.statLife > player.statLifeMax2 * 0.25)
            {
                if (player == Main.player[Main.myPlayer])
                {
                    player.hasPaladinShield = true;
                }
                else if (player.miscCounter % 5 == 0)
                {
                    var myPlayer = Main.myPlayer;
                    if (Main.player[myPlayer].team == player.team && player.team != 0)
                    {
                        var num45 = player.position.X - Main.player[myPlayer].position.X;
                        var num46 = player.position.Y - Main.player[myPlayer].position.Y;
                        var num47 = (float)Math.Sqrt(num45 * num45 + num46 * num46);
                        if (num47 < 800f)
                        {
                            Main.player[myPlayer].AddBuff(43, 10, true);
                        }
                    }
                }
            }
        }
    }
}
