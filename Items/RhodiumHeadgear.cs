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
	class RhodiumHeadgear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rhodium Headgear");
			Tooltip.SetDefault("10% increased ranged damage\nIncreases maximum mana by 20");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/RhodiumHeadgear");
			item.defense = 7;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.height = dims.Height;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<RhodiumPlateMail>() && legs.type == ModContent.ItemType<RhodiumGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "20% increased melee speed";
			player.meleeSpeed += 0.2f;
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 20;
			player.rangedDamage += 0.1f;
		}
	}
}