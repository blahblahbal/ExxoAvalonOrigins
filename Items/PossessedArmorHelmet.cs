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
	class PossessedArmorHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Possessed Armor Helmet");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/PossessedArmorHelmet");
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.vanity = true;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.height = dims.Height;
		}
	}
}