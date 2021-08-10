using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts
{
    public class FreezethrowerDust : ModDust
    {
        public override bool Update(Dust dust)
        {
            Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 135 / 255, 140 / 255, 1);
            return true;
        }
    }
}