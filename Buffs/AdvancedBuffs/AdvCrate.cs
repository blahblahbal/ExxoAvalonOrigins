﻿using Microsoft.Xna.Framework;
    public class AdvCrate : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Crate");
            Description.SetDefault("Greater chance of fishing up a crate");
        }

        public override void Update(Player player, ref int k)
        {
            player.cratePotion = true;
        }
    }