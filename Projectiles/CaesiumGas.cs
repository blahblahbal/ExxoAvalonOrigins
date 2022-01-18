using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class CaesiumGas : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caesium Gas");
        }
        public override void SetDefaults()
        {
            projectile.width = 70;
            projectile.height = 70;
            projectile.aiStyle = -1;
            projectile.penetrate = 1;
            projectile.alpha = 100;
            projectile.friendly = false;
            projectile.timeLeft = 720;
            projectile.ignoreWater = true;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.scale = 0.6f;
            projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
        }

        public override void AI()
        {
            projectile.ai[0]++;
            if (projectile.ai[0] > 500)
            {
                projectile.alpha++;
                if (projectile.alpha == 255) projectile.Kill();
            }
            projectile.velocity *= 0.98f;
            projectile.rotation += projectile.velocity.ToRotation() / 500;
            if (projectile.scale < 0.9f)
            {
                projectile.scale *= 1.005f;
            }
            if (Main.rand.Next(125) == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    int d = Dust.NewDust(projectile.position, 8, 8, ModContent.DustType<Dusts.CaesiumDust>());
                    Main.dust[d].velocity.X = Main.rand.NextFloat(-2f, 2f);
                    Main.dust[d].velocity.Y = Main.rand.NextFloat(-2f, 2f);
                }
            }
            foreach (Player p in Main.player)
            {
                if (p.active && !p.dead)
                {
                    if (p.getRect().Intersects(projectile.getRect()))
                    {
                        p.AddBuff(ModContent.BuffType<Buffs.CaesiumPoison>(), 5 * 60);
                    }
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
    }
}
