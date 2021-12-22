using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	class TroxiniumHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Troxinium Hat");
			Tooltip.SetDefault("10% increased magic damage\n15% decreased mana usage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 9;
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
			player.setBonus = "Hit mobs 15 times to trigger magic crits for 10 hits";
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().hyperMagic = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.1f;
			player.manaCost -= 0.15f;
		}
	}
}
