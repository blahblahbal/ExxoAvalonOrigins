﻿using Microsoft.Xna.Framework;
    public class AdvSummoning : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Summoning");
            Description.SetDefault("Increased max number of minions");
        }

        public override void Update(Player player, ref int k)
        {
            player.maxMinions += 2;
        }
    }