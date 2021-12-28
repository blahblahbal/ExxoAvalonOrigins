using Microsoft.Xna.Framework;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles
{
	public class TimesoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.LightYellow);
			Main.tileSolid[Type] = true;
			drop = ModContent.ItemType<SoulofTime>();
            dustType = ModContent.DustType<Dusts.ContagionSpray>();
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            int p = Player.FindClosest(new Vector2(i, j), 24, 24);
            if (p != 255)
            {
                if (WorldGen.tileCounts[Type] > 15)
                {
                    Main.player[p].accWatch = 3;
                }
            }
            if (Main.rand.Next(80) == 1)
            {
				int num162 = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, ModContent.DustType<Dusts.ContagionSpray>(), 0f, 0f, 0, default, 1f);
				Main.dust[num162].noGravity = true;
			}
        }
    }
}
