﻿using Microsoft.Xna.Framework;
    public class TuhrtlBrickWallUnsafe : ModWall
    {
        public override void SetDefaults()
        {
            drop = mod.ItemType("TuhrtlBrickWall");
            dustType = 1;
        }
    }