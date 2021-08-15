using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class CorruptedThornCrown : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrupted Thorn Crown");
			Tooltip.SetDefault("15% increased melee and ranged damage" +
				"\n35% increased magic damage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Armor/CorruptedThornCrown");
			item.defense = 7;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 2, 10, 0);
			item.height = dims.Height;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<CorruptedThornBodyarmor>() && legs.type == ModContent.ItemType<CorruptedThornGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();
			player.setBonus = "Blood Casting, Necrotic Aura, 75% increased mana usage";
			modPlayer.bloodCast = true;
			modPlayer.necroticAura = true;
			player.manaCost += 0.75f;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.15f;
			player.meleeDamage += 0.15f;
			player.magicDamage += 0.35f;
		}
	}
}
