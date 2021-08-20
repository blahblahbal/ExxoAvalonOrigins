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
    class AvalonCuisses : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avalon Cuisses");
			Tooltip.SetDefault("5% increased movement speed"
				+ "\nReduces the cooldown of healing potions"
				+ "\nIncreases maximum mana by 200"
				+ "\nLightning strikes when damaged");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Armor/AvalonCuisses");
			item.defense = 36;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 41, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.05f;
			player.pStone = true;
			player.statManaMax2 += 200;
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().liaB = true;
		}
	}
}
