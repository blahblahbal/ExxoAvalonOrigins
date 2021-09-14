using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvStrength : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Strength");
            Description.SetDefault("Increases stats");
        }

        public override void Update(Player player, ref int k)
        {
            player.meleeDamage += 0.15f;
            player.magicDamage += 0.15f;
            player.rangedDamage += 0.15f;
            player.minionDamage += 0.15f;
            player.thrownDamage += 0.15f;
            player.meleeCrit += 2;
            player.magicCrit += 2;
            player.rangedCrit += 2;
            player.statDefense += 7;
            player.lifeRegen += 2;
        }
    }
}