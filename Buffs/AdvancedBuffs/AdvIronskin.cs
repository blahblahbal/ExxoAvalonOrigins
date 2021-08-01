﻿using Microsoft.Xna.Framework;
    public class AdvIronskin : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Ironskin");
            Description.SetDefault("Increases defense by 16");
        }

        public override void Update(Player player, ref int k)
        {
            player.statDefense += 16;
        }
    }