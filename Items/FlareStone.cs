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
	class FlareStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flare Stone");
			Tooltip.SetDefault("Damage taken from lava contact is reduced\nWeapons inflict fire damage and provides immunity to fire blocks");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/FlareStone");
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 3, 50, 0);
			item.accessory = true;
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lavaRose = true;
			player.fireWalk = true;
			player.magmaStone = true;
		}
	}
}