using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	class FeroziumHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ferozium Helmet");
			Tooltip.SetDefault("20% increased melee and ranged damage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 17;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.value = 350000;
			item.height = dims.Height;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<FeroziumBreastplate>() && legs.type == ModContent.ItemType<FeroziumGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+7 defense and increased stats, melee and ranged attacks inflict Frostburn";
			player.statDefense += 7;
			player.frostArmor = true;
			player.frostBurn = true;
			player.meleeDamage += 0.1f;
			player.rangedDamage += 0.1f;
			player.meleeCrit += 2;
			player.rangedCrit += 2;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.2f;
			player.rangedDamage += 0.2f;
		}
	}
}
