using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	class VorazylcumHeadpiece : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vorazylcum Headpiece");
			Tooltip.SetDefault("20% increased damage\n7% increased critical strike chance");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 33;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 50, 0, 0);
			item.height = dims.Height;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<VorazylcumBodyplate>() && legs.type == ModContent.ItemType<VorazylcumLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().auraThorns = true;
            player.onHitDodge = true;
            player.setBonus = "Thorns Aura and Shadow Dodge";
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.2f;
			player.meleeDamage += 0.2f;
			player.minionDamage += 0.2f;
			player.magicDamage += 0.2f;
			player.magicCrit += 7;
			player.meleeCrit += 7;
			player.rangedCrit += 7;
		}
	}
}
