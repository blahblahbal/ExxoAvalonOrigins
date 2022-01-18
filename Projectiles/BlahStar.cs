using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class BlahStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah Star");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/BlahStar");
            projectile.aiStyle = 5;
            projectile.width = 20;
            projectile.height = 20;
            projectile.tileCollide = true;
            projectile.penetrate = 5;
            projectile.hostile = false;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, projectile.position, 10);
            for (int i = 0; i < 2; i++)
            {
                float speedX = projectile.velocity.X + Main.rand.Next(-51, 51) * 0.2f;
                float speedY = projectile.velocity.Y + Main.rand.Next(-51, 51) * 0.2f;
                int proj = Projectile.NewProjectile(projectile.position, new Vector2(speedX, speedY), ModContent.ProjectileType<BlahFire>(), projectile.damage, projectile.knockBack);
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].owner = projectile.owner;
                Main.projectile[proj].timeLeft = 240;
            }
            projectile.active = false;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
        public override void AI()
        {
            projectile.hostile = false;
            projectile.friendly = true;
            if (Main.rand.Next(100) == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    int d = Dust.NewDust(projectile.position, 10, 10, DustID.Fire);
                    Main.dust[d].noGravity = true;
                }
            }
        }
    }
}
