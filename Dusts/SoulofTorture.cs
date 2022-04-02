﻿using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts;

public class SoulofTorture : ModDust
{
    public override bool Update(Dust dust)
    {
        var lightFade = (dust.scale > 1 ? 1 : dust.scale);
        Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 1f * lightFade, 0f, 0f);
        return true;
    }
}