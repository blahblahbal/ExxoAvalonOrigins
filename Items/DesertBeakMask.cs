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
	[AutoloadEquip(EquipType.Head)]
	class DesertBeakMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Beak Mask");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/DesertBeakMask");
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.vanity = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.height = dims.Height;
		}
	}
}