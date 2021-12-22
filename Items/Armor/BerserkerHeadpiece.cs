using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	class BerserkerHeadpiece : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Berserker Headpiece");
			Tooltip.SetDefault("32% increased melee damage and 20% increased melee speed\n5% decreased melee critical strike chance");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 36;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 55, 0, 0);
			item.height = dims.Height;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<BerserkerBodyarmor>() && legs.type == ModContent.ItemType<BerserkerCuisses>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Melee weapons have a chance to instantly kill your enemies";
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().oblivionKill = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.32f;
			player.meleeSpeed += 0.2f;
			player.meleeCrit -= 5;
		}
	}
}
