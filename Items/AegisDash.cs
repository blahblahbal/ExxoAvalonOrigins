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
	[AutoloadEquip(EquipType.Shield)]
	class AegisDash : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aegis Dash");
			Tooltip.SetDefault("Dash into enemies to damage them");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/AegisDash");
			item.damage = 70;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.knockBack = 10f;
			item.accessory = true;
			item.value = Item.sellPrice(0, 7, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.dash = 2;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().dashIntoMob = true;
		}
	}
}