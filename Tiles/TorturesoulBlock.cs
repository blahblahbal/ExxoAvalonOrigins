using Microsoft.Xna.Framework;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles
{
	public class TorturesoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.DarkRed);
			Main.tileSolid[Type] = true;
			drop = ModContent.ItemType<SoulofTorture>();
            dustType = ModContent.DustType<Dusts.SoulofTorture>();
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            int p = Player.FindClosest(new Vector2(i, j), 24, 24);
            if (p != 255)
            {
                if (WorldGen.tileCounts[Type] > 15)
                {
                    Main.player[p].meleeCrit += 6;
                    Main.player[p].rangedCrit += 6;
                    Main.player[p].magicCrit += 6;
                    Main.player[p].thrownCrit += 6;
                }
            }
            Dust.NewDust(new Vector2(j * 16, i * 16), 16, 16, ModContent.DustType<Dusts.SoulofTorture>(), 0f, 0f, 0, default, 1f);
        }
    }
}
