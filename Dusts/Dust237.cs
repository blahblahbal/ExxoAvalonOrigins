using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts
{
	public class Dust237 : ModDust
	{
		public override bool Update(Dust dust)
		{
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.6f, 0.6f, 0f);
            return true;
        }
	}
}