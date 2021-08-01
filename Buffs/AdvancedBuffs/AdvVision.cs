﻿using Microsoft.Xna.Framework;
    public class AdvVision : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Vision");
            Description.SetDefault("Open caves light up");
        }

        public override void Update(Player player, ref int k)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().vision = true;
        }
    }