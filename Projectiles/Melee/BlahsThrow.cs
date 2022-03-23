using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee
{
    public class BlahsThrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah's Throw");
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 450f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 20f;
        }

        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 1f;
            //drawOriginOffsetX = -6;
            //drawOriginOffsetY = -6;
            //drawOffsetX = -6;
        }

        public override void PostAI()
        {
            //projectile.rotation++;
            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.Fire);
                dust.noGravity = true;
                dust.scale = 1.6f;
            }
        }
    }
}
