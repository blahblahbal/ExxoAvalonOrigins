using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles
{
	public class CoolGemsparkBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.DarkCyan);
			Main.tileSolid[Type] = true;
			Main.tileBrick[Type] = true;
			drop = mod.ItemType("CoolGemsparkBlock");
            dustType = DustID.Ebonwood;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Texture2D texture;
            if (Main.canDrawColorTile(i, j))
            {
                texture = Main.tileAltTexture[Type, (int)tile.color()];
            }
            else
            {
                texture = Main.tileTexture[Type];
            }
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, 16), new Color(ExxoAvalonOrigins.gbvR, ExxoAvalonOrigins.gbvG, ExxoAvalonOrigins.gbvB), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        }
    }
}