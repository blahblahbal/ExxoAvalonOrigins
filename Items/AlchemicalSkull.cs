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
	class AlchemicalSkull : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemical Skull");
			Tooltip.SetDefault("Increases spawn rate and Attackers also take damage"
				+ "\nThe wearer can walk on water and lava" 
				+ "\nGrants immunity to knockback and fire blocks");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/AlchemicalSkull");
			item.defense = 8;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.accessory = true;
			item.value = 150000;
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.waterWalk = (player.waterWalk2 = (player.enemySpawns = /*(player.thorns = */(player.noKnockback = (player.fireWalk = true))/*)*/));
		}
	}
}