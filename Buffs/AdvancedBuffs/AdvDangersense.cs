﻿using Microsoft.Xna.Framework;
    public class AdvDangersense : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Dangersense");
            Description.SetDefault("You can see nearby hazards");
        }

        public override void Update(Player player, ref int k)
        {
            player.dangerSense = true;
        }
    }