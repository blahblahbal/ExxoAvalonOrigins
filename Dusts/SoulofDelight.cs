using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts
{
    public class SoulofDelight : ModDust
    {
        public override bool Update(Dust dust)
        {
            Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), (189 / 255), (133 / 255), 1f);
            return true;
        }
    }
}
