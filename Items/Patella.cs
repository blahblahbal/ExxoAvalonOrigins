using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class Patella : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Patella");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Patella");
			item.width = dims.Width;
			item.value = 90;
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}