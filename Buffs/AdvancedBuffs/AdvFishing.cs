﻿using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvFishing : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Fishing");
            Description.SetDefault("Increased fishing level");
        }

        public override void Update(Player player, ref int k)
        {
            player.fishingSkill += 30;
        }
    }
}