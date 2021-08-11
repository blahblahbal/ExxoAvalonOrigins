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
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles
{
	public class PyroscoricOre : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(255, 102, 0), LanguageManager.Instance.GetText("Pyroscoric"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileValue[Type] = 820;
            drop = mod.ItemType("PyroscoricOre");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = 174;
            minPick = 210;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            float num7 = (float)Main.rand.Next(90, 111) * 0.01f;
            num7 *= Main.essScale;
            r = 0.5f * num7;
            g = 0.2f * num7;
            b = 0.05f * num7;
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            Vector2 pos = new Vector2(i * 16, j * 16) + zero - Main.screenPosition;
            Rectangle frame = new Rectangle(tile.frameX, tile.frameY, 16, 16);
            Main.spriteBatch.Draw(mod.GetTexture("Tiles/PyroscoricOre_Glow"), pos, frame, Color.White);
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.rand.Next(200) == 1)
            {
                int randomSize = Main.rand.Next(1, 4) / 2;
                int num161 = Gore.NewGore(new Vector2(i * 16, j * 16), default(Vector2), Main.rand.Next(61, 64));
                Gore gore30 = Main.gore[num161];
                Gore gore40 = gore30;
                gore40.velocity *= 0.3f;
                gore40.scale *= randomSize;
                Main.gore[num161].velocity.X += Main.rand.Next(-1, 2);
                Main.gore[num161].velocity.Y += Main.rand.Next(-1, 2);
            }
            if (Main.rand.Next(120) == 1)
            {
                int num162 = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, 6, 0f, 0f, 0, default(Color), 2f);
                Main.dust[num162].noGravity = true;
                Main.dust[num162].velocity *= 4f;
                Main.dust[num162].noLight = true;
            }
            if (Main.rand.Next(120) == 1)
            {
                int num162 = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Smoke, 0f, 0f, 0, default(Color), 1.5f);
                Main.dust[num162].noGravity = true;
                Main.dust[num162].velocity *= 1.5f;
                Main.dust[num162].noLight = true;
            }
        }
    }
}