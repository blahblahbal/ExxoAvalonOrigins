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
	class UnvolanditeHeadpiece : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unvolandite Headpiece");
			Tooltip.SetDefault("16% increased damage\n6% increased critical strike chance");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/UnvolanditeHeadpiece");
			item.defense = 32;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 50, 0, 0);
			item.height = dims.Height;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<UnvolanditeBodyplate>() && legs.type == ModContent.ItemType<UnvolanditeLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.onHitPetal = true;
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().hyperMelee = true;
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().hyperMagic = true;
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().hyperRanged = true;
			player.setBonus = "Petals attack your enemies and Hyper Damage";
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.16f;
			player.meleeDamage += 0.16f;
			player.minionDamage += 0.16f;
			player.magicDamage += 0.16f;
			player.magicCrit += 6;
			player.meleeCrit += 6;
			player.rangedCrit += 6;
		}
	}
}