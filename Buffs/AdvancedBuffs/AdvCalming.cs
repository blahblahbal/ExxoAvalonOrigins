﻿using Microsoft.Xna.Framework;
    public class AdvCalming : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Calm");
            Description.SetDefault("Reduced enemy aggression");
        }

        public override void Update(Player player, ref int k)
        {
            player.calmed = true;
        }
    }