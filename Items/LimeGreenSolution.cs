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
	class LimeGreenSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lime Solution");
			Tooltip.SetDefault("Used by the Clentaminator\nSpreads the Jungle");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/LimeGreenSolution");
			item.ammo = AmmoID.Solution;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
            item.consumable = true;
			item.shoot = ModContent.ProjectileType<Projectiles.LimeSolution>() - ProjectileID.PureSpray;
			item.value = Item.buyPrice(0, 0, 25, 0);
			item.maxStack = 2000;
			item.height = dims.Height;
		}
        public override bool ConsumeAmmo(Player player)
        {
            return player.itemAnimation >= player.HeldItem.useAnimation - 3;
        }
    }
}