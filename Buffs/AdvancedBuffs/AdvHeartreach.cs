﻿using Microsoft.Xna.Framework;
    public class AdvHeartreach : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Heartreach");
            Description.SetDefault("Increased heart pickup range");
        }

        public override void Update(Player player, ref int k)
        {
            player.lifeMagnet = true;
        }
    }