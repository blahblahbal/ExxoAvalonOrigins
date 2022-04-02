using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts;

public class BlackSolutionDust : ModDust
{
    public override bool Update(Dust dust)
    {
        var lightFade = (dust.scale > 1 ? 1 : dust.scale);
        Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), (0.1f * lightFade), (0.1f * lightFade), (0.1f * lightFade));
        return true;
    }
    public override Color? GetAlpha(Dust dust, Color lightColor)
    {
        return new Color(255, 255, 255, 100);
    }
}