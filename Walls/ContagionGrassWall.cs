﻿using Microsoft.Xna.Framework;
    public class ContagionGrassWall : ModWall
    {
        public override void SetDefaults()
        {
            soundType = SoundID.Grass;
            soundStyle = 1;
            WallID.Sets.Conversion.Grass[base.Type] = true;
        }
    }