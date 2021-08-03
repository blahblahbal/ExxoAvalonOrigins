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
	public class BorealWoodBeam : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(73, 51, 36));
			//Main.tileBeam[Type] = true;
			drop = mod.ItemType("BorealWoodBeam");
		}

        //public override bool CanPlace(int i, int j)        //{        //    return ExxoAvalonOrigins.beams.Contains(Main.tile[i - 1, j].type) || ExxoAvalonOrigins.beams.Contains(Main.tile[i + 1, j].type) || ExxoAvalonOrigins.beams.Contains(Main.tile[i, j - 1].type) || ExxoAvalonOrigins.beams.Contains(Main.tile[i, j + 1].type);        //}
    }
}