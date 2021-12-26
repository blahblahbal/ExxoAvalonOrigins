﻿using Microsoft.Xna.Framework;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles
{
	public class JunglesoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.LimeGreen);
			Main.tileSolid[Type] = true;
			drop = ModContent.ItemType<SouloftheJungle>();
            dustType = ModContent.DustType<Dusts.SoulofHumidity>();
		}
        public override void NearbyEffects(int i, int j, bool closer)
        {
            Dust.NewDust(new Vector2(j * 16, i * 16), 16, 16, ModContent.DustType<Dusts.SoulofHumidity>(), 0f, 0f, 0, default, 1f);
        }
    }
}
