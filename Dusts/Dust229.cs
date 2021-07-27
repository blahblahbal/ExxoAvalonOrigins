using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts
{
	public class Dust229 : ModDust
	{
		public override bool Update(Dust dust)
		{
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.368627459f, 0.101960786f, 0.8666667f);
            return true;
        }
	}
}