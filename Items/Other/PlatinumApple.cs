using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Other
{
    class PlatinumApple : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Platinum Apple");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.width = dims.Width;
            Item.height = dims.Height;
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
            SoundEngine.PlaySound(SoundID.Grab, player.position);
            return false;
        }
    }
}
