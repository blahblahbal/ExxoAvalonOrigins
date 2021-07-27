using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts
{
	public class Dust233 : ModDust
	{
		public override bool Update(Dust dust)
		{
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.003921569f, 0.4862745f, 0.6313726f);
            return true;
        }
	}
}