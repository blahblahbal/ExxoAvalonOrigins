using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Other
{
	class PlatinumHeart : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Platinum Heart");
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
            if (player.statLife + 55 > player.statLifeMax2) player.statLife = player.statLifeMax2; else player.statLife += 55;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(55, true);
            }
            Main.PlaySound(SoundID.Grab, player.position);
            return false;
        }
    }
}
