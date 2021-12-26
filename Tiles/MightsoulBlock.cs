﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles
{
	public class MightsoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.Blue);
			Main.tileSolid[Type] = true;
			drop = ItemID.SoulofMight;
            dustType = ModContent.DustType<Dusts.SoulofMight>();
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Main.rand.Next(100) == 0)
            {
                Dust.NewDust(new Vector2(j * 16, i * 16), 16, 16, ModContent.DustType<Dusts.SoulofMight>(), 0f, 0f, 0, default, 1f);
            }
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            int p = Player.FindClosest(new Vector2(i, j), 24, 24);
            if (p != 255)
            {
                if (WorldGen.tileCounts[Type] > 15)
                {
                    Main.player[p].meleeDamage += 0.1f;
                    Main.player[p].rangedDamage += 0.1f;
                    Main.player[p].magicDamage += 0.1f;
                    Main.player[p].minionDamage += 0.1f;
                    Main.player[p].thrownDamage += 0.1f;
                }
            }
            base.NearbyEffects(i, j, closer);
        }
    }
}
