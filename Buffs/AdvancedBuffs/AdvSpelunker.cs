﻿using Microsoft.Xna.Framework;
    public class AdvSpelunker : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Spelunker");
            Description.SetDefault("Shows the location of treasure and ore");
        }

        public override void Update(Player player, ref int k)
        {
            player.findTreasure = true;
        }
    }