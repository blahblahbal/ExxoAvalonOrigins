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
	class CloakofAssists : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cloak of Assists");
			Tooltip.SetDefault("Increases movement speed after being damaged and releases bees when injured\nStars fall and lightning strikes when damaged");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/CloakofAssists");
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.bee = (player.starCloak = (player.panic = (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().LightningInABottle = true)));
		}
	}
}