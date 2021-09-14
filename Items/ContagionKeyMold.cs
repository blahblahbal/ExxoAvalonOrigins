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
	class ContagionKeyMold : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Contagion Key Mold");
			Tooltip.SetDefault("Used for crafting a Contagion Key");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/ContagionKeyMold");
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.scale = 1f;
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}