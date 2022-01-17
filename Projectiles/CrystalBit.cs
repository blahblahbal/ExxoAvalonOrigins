using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles
{
    public class CrystalBit : ModProjectile
    {
        int rn = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Shard");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/CrystalBit");
            projectile.aiStyle = -1;
            projectile.width = 20;
            projectile.height = 20;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.alpha = 100;
            projectile.timeLeft = 180;
            rn = Main.rand.Next(60, 121);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity.X = oldVelocity.X * -0.02f;
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = oldVelocity.X * -0.5f;
            }
            if (projectile.velocity.Y != oldVelocity.Y && oldVelocity.Y > 1f)
            {
                projectile.velocity.Y = oldVelocity.Y * -0.5f;
            }
            return false;
        }
        public override void AI()
        {
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.velocity *= 0.85f;
            projectile.rotation = (float)System.Math.Atan2(projectile.Center.Y - Main.player[Player.FindClosest(projectile.position, projectile.width, projectile.height)].Center.Y, projectile.Center.X - Main.player[Player.FindClosest(projectile.position, projectile.width, projectile.height)].Center.X) - 1.57079633f;
            //projectile.ai[1]++;
            //if (projectile.ai[1] > 5f)
            //{
            //    projectile.ai[1] = 5f;
            //    if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
            //    {
            //        projectile.velocity.X = projectile.velocity.X * 0.97f;
            //        if (projectile.velocity.X > -0.01 && projectile.velocity.X < 0.01)
            //        {
            //            projectile.velocity.X = 0f;
            //            projectile.netUpdate = true;
            //        }
            //    }
            //    projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            //}
            projectile.ai[0]++;
            if (projectile.ai[0] > rn)
            {
                Main.PlaySound(2, projectile.position, 43);
                int p = Projectile.NewProjectile(projectile.position, projectile.velocity, ModContent.ProjectileType<CrystalBeam>(), 67, projectile.knockBack, Main.myPlayer);
                Main.projectile[p].velocity = Vector2.Normalize(Main.player[Player.FindClosest(projectile.position, projectile.width, projectile.height)].position - projectile.position) * 7f;
                projectile.active = false;
            }
        }
    }
}
