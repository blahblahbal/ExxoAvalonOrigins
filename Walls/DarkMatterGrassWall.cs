using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Walls
{
	public class DarkMatterGrassWall : ModWall
	{
		public override void SetDefaults()
		{
            AddMapEntry(new Color(58, 37, 53));
            soundType = SoundID.Grass;
            soundStyle = 1;
            dustType = DustID.UnholyWater;
		}
	}
}
