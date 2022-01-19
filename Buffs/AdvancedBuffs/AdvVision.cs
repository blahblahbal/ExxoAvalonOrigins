﻿using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvVision : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Vision");
            Description.SetDefault("Open caves light up");
        }

        public override void Update(Player player, ref int k)
        {
            player.Avalon().vision = true;
        }
    }
}