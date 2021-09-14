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
	class Bloodberry : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodberry");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Bloodberry");
			item.width = dims.Width;
			item.maxStack = 999;
			item.value = 100;
			item.height = dims.Height;
		}
	}
}