using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class AncientSandy : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandy");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/AncientSandy");
            projectile.width = dims.Width * 20 / 16;
            projectile.height = dims.Height * 20 / 16 / Main.projFrames[projectile.type];
            projectile.scale = 1f;
            projectile.alpha = 255;
            projectile.aiStyle = -1;
            projectile.timeLeft = 3600;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            var newColor2 = default(Color);
            var num972 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Gold, 0f, 0f, 100, newColor2, 2f);
            Main.dust[num972].noGravity = true;
            return;
        }
    }
}