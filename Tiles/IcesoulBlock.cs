using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles
{
	public class IcesoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(0, 0, 200));
			Main.tileSolid[Type] = true;
			drop = ModContent.ItemType<SoulofIce>();
            dustType = ModContent.DustType<Dusts.SoulofFlight>();
		}
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Main.rand.Next(100) == 0)
            {
                Dust.NewDust(new Vector2(j * 16, i * 16), 16, 16, ModContent.DustType<Dusts.SoulofFlight>(), 0f, 0f, 0, default, 1f);
            }
        }
    }
}
