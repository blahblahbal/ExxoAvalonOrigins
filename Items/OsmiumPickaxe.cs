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
	class OsmiumPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Osmium Pickaxe");
			Tooltip.SetDefault("Can mine Hellstone");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/OsmiumPickaxe");
			item.damage = 13;
			item.autoReuse = true;
			item.useTurn = true;
			item.crit += 6;
			item.pick = 95;
			item.rare = 3;
			item.width = dims.Width;
			item.useTime = 13;
			item.knockBack = 3f;
			item.melee = true;
			item.useStyle = 1;
			item.value = 50000;
			item.useAnimation = 13;
			item.height = dims.Height;
		}

        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == mod.ItemType("OsmiumPickaxe"))
            {
                player.pickSpeed -= 0.5f;
            }
        }
    }
}