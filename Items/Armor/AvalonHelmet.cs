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
    [AutoloadEquip(EquipType.Head)]
    class AvalonHelmet : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avalon Helmet");
			Tooltip.SetDefault("32% increased damage"
				+ "\n10% increased melee speed"
				+ "\n20% decreased mana usage"
				+ "\nSummons a leaf storm when damaged");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Armor/AvalonHelmet");
			item.defense = 70;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 41, 0, 0);
			item.height = dims.Height;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<AvalonBodyarmor>() && legs.type == ModContent.ItemType<AvalonCuisses>();
		}

		public override void UpdateArmorSet(Player player)
		{
			ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();
			player.setBonus = "Restoration"
				+ "\nDealing a critical hit temporarily gives the 'Blessing of Avalon' buff"
				+ "\nThis buff removes almost all debuffs and greatly increases your stats"
				+ "\n\nRetribution"
				+ "\nEnemies who strike you are marked for their destruction"
				+ "\nThey will take quadruple damage from your next attack";

			modPlayer.avalonRestoration = true;
			modPlayer.avalonRetribution = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.allDamage += 0.32f;
			player.meleeSpeed += 0.10f;
			player.manaCost -= 0.20f;
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().leafStorm = true;
		}
	}
}
