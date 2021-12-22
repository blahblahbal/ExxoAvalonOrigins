using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class GiftofStarpower : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gift of Starpower");
			Tooltip.SetDefault("20% decreased mana usage and +40 mana\nAutomatically use mana potions when needed and 15% increased magic damage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.manaCost -= 0.2f;
			player.statManaMax2 += 40;
			player.manaFlower = true;
			player.magicDamage += 0.15f;
		}
	}
}
