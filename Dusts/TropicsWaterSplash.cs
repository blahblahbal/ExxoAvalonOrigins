﻿using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts
{
    public class TropicsWaterSplash : ModDust
    {
        public override void SetStaticDefaults()
        {
            updateType = 33;
        }

        public override void OnSpawn(Dust dust)
        {
            dust.alpha = 170;
            dust.velocity *= 0.5f;
            dust.velocity.Y += 1f;
        }
    }
}