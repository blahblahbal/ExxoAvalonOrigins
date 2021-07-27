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
	class RhodiumPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rhodium Pickaxe");
			Tooltip.SetDefault("Can mine Hellstone");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/RhodiumPickaxe");
			item.damage = 11;
			item.autoReuse = true;
			item.useTurn = true;
			item.crit += 5;
			item.pick = 65;
			item.rare = 3;
			item.width = dims.Width;
			item.useTime = 13;
			item.knockBack = 2f;
			item.melee = true;
			item.useStyle = 1;
			item.value = 50000;
			item.useAnimation = 15;
			item.height = dims.Height;
		}

        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == mod.ItemType("RhodiumPickaxe"))
            {
                player.pickSpeed -= 0.5f;
            }
        }
    }
}