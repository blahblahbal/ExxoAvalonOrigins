using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts
{
	public class Dust234 : ModDust
	{
		public override bool Update(Dust dust)
		{
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.105882354f, 0.105882354f, 0.105882354f);
            return true;
        }
	}
}