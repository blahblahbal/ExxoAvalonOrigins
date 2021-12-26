﻿using Microsoft.Xna.Framework;
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
	public class FlightsoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.LightCyan);
			Main.tileSolid[Type] = true;
			drop = ItemID.SoulofFlight;
            dustType = ModContent.DustType<Dusts.SoulofFlight>();
		}
        public override void NearbyEffects(int i, int j, bool closer)
        {
            Dust.NewDust(new Vector2(j * 16, i * 16), 16, 16, ModContent.DustType<Dusts.SoulofFlight>(), 0f, 0f, 0, default, 1f);
        }
    }
}
