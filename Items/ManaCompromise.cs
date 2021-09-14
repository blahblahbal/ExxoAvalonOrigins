using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
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
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/ManaCompromise");
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