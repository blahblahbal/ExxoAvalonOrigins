using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts
{
	public class SoulofLight : ModDust
	{
		public override bool Update(Dust dust)
		{
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 1f, 0.121568628f, 0.68235296f);
            return true;
		}
	}
}
