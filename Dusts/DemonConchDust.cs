using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts;

public class DemonConchDust : ModDust
{
    public override bool Update(Dust dust)
    {
        var num67 = dust.scale * 0.1f;
        if (num67 > 1f)
        {
            num67 = 1f;
        }
        Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num67 * 0.33f, num67 * 0.24f, num67 * 0.59f);
        return true;
    }
}