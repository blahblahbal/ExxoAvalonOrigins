using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts;

public class TritanoriumFlame : ModDust
{
    public override bool Update(Dust dust)
    {
        var lightFade = (dust.scale > 1 ? 1 : dust.scale);
        if (!dust.noLight)
        {
            if (dust.frame.Y >= 10)
            {
                Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0, ((float)174 / 255 * lightFade), 1 * lightFade);
            }
            else
            {
                Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), ((float)156 / 255 * lightFade), ((float)180 / 255 * lightFade), ((float)120 / 255 * lightFade));
            }
            return true;
        }
        return true;
    }
    public override Color? GetAlpha(Dust dust, Color lightColor)
    {
        return new Color(255, 255, 255, 50);
    }
}