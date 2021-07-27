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
	class TroxiniumHeadpiece : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Troxinium Headpiece");
			Tooltip.SetDefault("9% increased ranged damage\n30% chance to not consume ammo");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TroxiniumHeadpiece");
			item.defense = 11;
			item.rare = 5;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 3, 40, 0);
			item.height = dims.Height;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
        {
			return body.type == ModContent.ItemType<TroxiniumBodyarmor>() && legs.type == ModContent.ItemType<TroxiniumCuisses>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Hit mobs 15 times to trigger ranged crits for 10 hits";
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().hyperRanged = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.09f;
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ammoCost70 = true;
		}
	}
}