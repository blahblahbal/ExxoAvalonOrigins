using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Walls
{
	public class DarkMatterSoilWall : ModWall
	{
		public override void SetDefaults()
		{
            AddMapEntry(new Color(103, 48, 84));
            dustType = DustID.UnholyWater;
		}
	}
}
