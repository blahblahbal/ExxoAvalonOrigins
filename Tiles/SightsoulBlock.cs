using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles
{
	public class SightsoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.Green);
			Main.tileSolid[Type] = true;
			drop = ItemID.SoulofSight;
            dustType = ModContent.DustType<Dusts.SoulofSight>();
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.rand.Next(100) == 0)
            {
				int num162 = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, ModContent.DustType<Dusts.SoulofSight>(), 0f, 0f, 0, default, 1f);
				Main.dust[num162].noGravity = true;
			}
        }
    }
}
