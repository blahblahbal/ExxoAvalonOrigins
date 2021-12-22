using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class ManaCompromise : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Compromise");
			Tooltip.SetDefault("Increases maximum mana by 100\n10% decreased magic damage and 7% decreased mana usage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 6, 70, 0);
			item.accessory = true;
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 100;
			player.magicDamage -= 0.1f;
			player.manaCost -= 0.07f;
		}
	}
}
