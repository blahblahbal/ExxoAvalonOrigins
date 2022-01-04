using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Other
{
	class GoldApple : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Apple");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
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
