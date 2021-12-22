using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class DivingSuit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diving Suit");
			Tooltip.SetDefault("Greatly extends underwater breathing\n10% increased damage while in water");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 4;
			item.rare = ItemRarityID.Green;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			player.breathMax *= 3; //TODO: fix.
			if (player.wet)
			{
				player.meleeDamage += 0.1f;
				player.magicDamage += 0.1f;
				player.rangedDamage += 0.1f;
			}
		}
	}
}
