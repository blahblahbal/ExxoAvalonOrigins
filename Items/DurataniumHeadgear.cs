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
	class DurataniumHeadgear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duratanium Headgear");
			Tooltip.SetDefault("6% increased magic damage\n5% decreased mana usage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/DurataniumHeadgear");
			item.defense = 4;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 1, 40, 0);
			item.height = dims.Height;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<DurataniumChainmail>() && legs.type == ModContent.ItemType<DurataniumGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Defense is increased by 12 while you are affected by a debuff";
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().defDebuff = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.06f;
			player.manaCost -= 0.05f;
		}
	}
}