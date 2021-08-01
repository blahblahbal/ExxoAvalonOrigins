﻿using Microsoft.Xna.Framework;
    public class AdvRogue : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Rogue");
            Description.SetDefault("-5% ranged damage, 25% chance to not consume ammo");
        }

        public override void Update(Player player, ref int k)
        {
            player.ammoCost75 = true;
            player.rangedDamage -= 0.05f;
        }
    }