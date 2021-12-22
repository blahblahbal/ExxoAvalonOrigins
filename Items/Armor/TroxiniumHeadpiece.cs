using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
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
			Rectangle dims = this.GetDims();
			item.defense = 11;
			item.rare = ItemRarityID.Pink;
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
