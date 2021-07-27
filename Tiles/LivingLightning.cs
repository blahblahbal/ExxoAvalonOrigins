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
	public class LivingLightning : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			drop = mod.ItemType("LivingLightning");
		}

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.6f;
            g = 0.1f;
            b = 0.6f;
        }
    }
}