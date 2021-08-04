using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles{	public class OpalGemspark : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(165, 255, 127));			Main.tileSolid[Type] = true;			Main.tileLighted[Type] = true;			Main.tileShine2[Type] = true;			drop = mod.ItemType("OpalGemspark");		}        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)        {            r = Main.DiscoR / 255f * 1.5f;            g = Main.DiscoG / 255f * 1.5f;            b = Main.DiscoB / 255f * 1.5f;        }        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
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
            Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, 16), new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        }    }}