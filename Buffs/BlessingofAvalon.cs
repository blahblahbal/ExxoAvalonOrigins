using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class BlessingofAvalon : ModBuff
    {
        List<int> dontRemove = new List<int>()
        {
            BuffID.Horrified,
            BuffID.TheTongue,
            BuffID.MoonLeech,
            BuffID.PotionSickness,
            BuffID.ManaSickness,
            BuffID.Merfolk,
            BuffID.Werewolf,
            BuffID.ChaosState,
            ModContent.BuffType<CurseofIcarus>()
        };
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blessing of Avalon");
            Description.SetDefault("You are immune to almost all debuffs"
                + "\nYour stats are greatly increased");
        }

        public override void Update(Player player, ref int k)
        {
            for (int i = 0; i < player.buffType.Length; i++)
            {
                int buffID = player.buffType[i];
                if (Main.debuff[buffID])
                {
                    /*if (buffID != BuffID.Horrified || 
						buffID != BuffID.TheTongue || 
						buffID != BuffID.MoonLeech || 
						buffID != BuffID.PotionSickness ||
						buffID != BuffID.ManaSickness ||
						buffID != BuffID.Merfolk ||
						buffID != BuffID.Werewolf ||
						buffID != BuffID.ChaosState ||
						buffID != ModContent.BuffType<CurseofIcarus>())*/
                    if (!dontRemove.Contains(buffID))
                    {
                        player.ClearBuff(buffID);
                    }
                }
            }

            player.allDamage += 0.2f;
            player.meleeCrit += 10;
            player.magicCrit += 10;
            player.rangedCrit += 10;
            player.thrownCrit += 10;
            player.Avalon().critDamageMult += 0.3f;
            player.statDefense += 10;
            player.lifeRegen += 3;
            player.manaRegen += 3;
            player.armorPenetration += 10;
            player.manaCost -= 0.2f;
        }
    }
}