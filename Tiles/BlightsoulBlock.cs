using Microsoft.Xna.Framework;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles
{
	public class BlightsoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.DarkGray);
			Main.tileSolid[Type] = true;
			drop = ModContent.ItemType<SoulofBlight>();
            dustType = ModContent.DustType<Dusts.SoulofBlight>();
		}
        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
        {
            if (Main.rand.Next(100) == 0)
            {
                Dust.NewDust(new Vector2(j * 16, i * 16), 16, 16, ModContent.DustType<Dusts.SoulofBlight>(), 0f, 0f, 0, default, 1f);
            }
        }
    }
}
