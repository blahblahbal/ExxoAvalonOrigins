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
		}

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 3f;
            g = 3f;
            b = 3f;
        }
    }
}