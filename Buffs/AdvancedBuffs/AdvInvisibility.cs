﻿using Microsoft.Xna.Framework;
    public class AdvInvisibility : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Invisibility");
            Description.SetDefault("Grants invisibility");
        }

        public override void Update(Player player, ref int k)
        {
            player.invis = true;
        }
    }