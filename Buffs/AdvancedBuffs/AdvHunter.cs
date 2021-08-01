﻿using Microsoft.Xna.Framework;
    public class AdvHunter : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Hunter");
            Description.SetDefault("Shows the location of enemies");
        }

        public override void Update(Player player, ref int k)
        {
            player.detectCreature = true;
        }
    }