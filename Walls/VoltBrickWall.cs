using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Walls
{
	public class VoltBrickWall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			drop = mod.ItemType("VoltBrickWall");
            AddMapEntry(Color.MediumPurple);
			dustType = DustID.PurpleTorch;
		}
	}
}
