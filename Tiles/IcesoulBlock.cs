using Microsoft.Xna.Framework;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
	public class IcesoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(0, 0, 200));
			Main.tileSolid[Type] = true;
			drop = ModContent.ItemType<SoulofIce>();
            dustType = ModContent.DustType<Dusts.SoulofFlight>();
		}
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.rand.Next(80) == 1)
            {
				int num162 = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, ModContent.DustType<Dusts.SoulofFlight>(), 0f, 0f, 0, default, 1f);
				Main.dust[num162].noGravity = true;
			}
        }
    }
}
