using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class DivineLightTreads : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Divine Light Treads");
			Tooltip.SetDefault("25% increased movement speed" +
				"\n20% increased arrow damage and velocity");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Armor/DivineLightTreads");
			item.defense = 15;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 1, 80, 0);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.25f;
			player.archery = true;
		}
	}
}
