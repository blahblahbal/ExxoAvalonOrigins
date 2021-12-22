using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class ForsakenRelic : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forsaken Relic");
			Tooltip.SetDefault("Increases damage and critical strike chance by 7% while invincible");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Pink;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
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
