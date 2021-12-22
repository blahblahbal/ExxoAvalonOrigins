using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class ForsakenCross : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forsaken Cross");
			Tooltip.SetDefault("Increases damage and critical strike chance by 7% while invincible\nIncreases length of invincibility after taking damage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.longInvince = true;
			if (player.immune)
			{
				player.magicCrit += 7;
				player.meleeCrit += 7;
				player.rangedCrit += 7;
				player.magicDamage += 0.07f;
				player.meleeDamage += 0.07f;
				player.rangedDamage += 0.07f;
				player.minionDamage += 0.07f;
			}
		}
	}
}
