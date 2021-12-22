using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class ChaosEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Emblem");
			Tooltip.SetDefault("10% increased critical strike damage\n10% increased damage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.minionDamage += 0.1f;
			player.meleeDamage += 0.1f;
			player.magicDamage += 0.1f;
			player.rangedDamage += 0.1f;
			player.bulletDamage += 0.1f;
			player.rocketDamage += 0.1f;
			player.arrowDamage += 0.1f;
		}
	}
}
