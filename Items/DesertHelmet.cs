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
	class DesertHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Helmet");
			Tooltip.SetDefault("5% decreased mana usage\n5% increased ranged damage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/DesertHelmet");
			item.defense = 5;
			item.rare = ItemRarityID.Green;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.height = dims.Height;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<DesertChainmail>() && legs.type == ModContent.ItemType<DesertGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "15% increased magic damage";
			player.magicDamage += 0.15f;
		}

		public override void UpdateEquip(Player player)
		{
			player.manaCost -= 0.05f;
			player.rangedDamage += 0.05f;
		}
	}
}