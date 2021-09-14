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
	class GoldCandyCane : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Candy Cane");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/GoldCandyCane");
			item.width = dims.Width;
			item.height = dims.Height;
		}

        public override bool CanPickup(Player player)
        {
            return true;
        }

        public override bool OnPickup(Player player)
        {
            if (player.statLife + 40 > player.statLifeMax2) player.statLife = player.statLifeMax2; else player.statLife += 40;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(40, true);
            }
            Main.PlaySound(SoundID.Grab, player.position);
            return false;
        }
    }
}