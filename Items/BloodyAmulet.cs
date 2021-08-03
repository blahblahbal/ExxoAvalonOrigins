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
	class BloodyAmulet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloody Amulet");
			Tooltip.SetDefault("Summons a Blood Moon");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BloodyAmulet");
			item.UseSound = SoundID.Item4;
			item.consumable = true;
			item.rare = 3;
			item.width = dims.Width;
			item.useTime = 40;
			item.shoot = ModContent.ProjectileType<Projectiles.BloodyAmulet>();
			item.useStyle = 1;
			item.maxStack = 20;
			item.useAnimation = 40;
			item.height = dims.Height;
		}
        public override bool CanUseItem(Player player)
        {
            if (Main.pumpkinMoon) return false;
            if (Main.snowMoon) return false;
            if (Main.dayTime) return false;
            return true;
        }
    }
}