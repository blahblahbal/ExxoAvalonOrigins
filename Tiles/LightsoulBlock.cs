using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles
{
	public class LightsoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.LightPink);
			Main.tileSolid[Type] = true;
			Main.tileLighted[Type] = true;
            drop = ItemID.SoulofLight;
            dustType = ModContent.DustType<Dusts.SoulofLight>();
		}
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Main.rand.Next(100) == 0)
            {
                Dust.NewDust(new Vector2(j * 16, i * 16), 16, 16, ModContent.DustType<Dusts.SoulofLight>(), 0f, 0f, 0, default, 1f);
            }
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 3f;
            g = 3f;
            b = 3f;
        }
    }
}
