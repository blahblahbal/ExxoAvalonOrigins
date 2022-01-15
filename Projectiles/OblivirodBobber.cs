using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class OblivirodBobber : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oblivirod Bobber");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = 61;
            projectile.bobber = true;
            projectile.penetrate = -1;
        }

        public override bool PreDrawExtras(SpriteBatch spriteBatch)
        {
            return projectile.DrawFishingLine(ModContent.ItemType<Items.Tools.Oblivirod>(), new Color(234, 113, 201, 100));
        }
    }
}
