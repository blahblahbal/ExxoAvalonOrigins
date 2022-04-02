using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts;

public class ContagionSpray : ModDust
{
    public override bool Update(Dust dust)
    {
        Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.6f, 0.6f, 0f);
        return true;
    }
    //public override Color GetAlpha(Color newColor)
    //{
    //	return new Color(200, 200, 200, 0);
    //}
    public override Color? GetAlpha(Dust dust, Color lightColor)
    {
        return new Color(255, 255, 255, 100);
    }
}