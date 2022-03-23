using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class DevilScythe : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Devil Scythe");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/DevilScythe");
            projectile.width = 48;
            projectile.height = 48;
            projectile.alpha = 100;
            projectile.light = 0.5f;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 4;
            projectile.tileCollide = true;
            projectile.scale = 0.9f;
            projectile.magic = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
            int num234 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.7f);
            Main.dust[num234].noGravity = true;
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f);
            return true;
        }
        public override void AI()
        {
            if (projectile.ai[1] == 0f && projectile.type == ProjectileID.DemonSickle)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 8);
            }
            if (projectile.type == ProjectileID.IceSickle || projectile.type == ProjectileID.DeathSickle || projectile.type == ModContent.ProjectileType<Melee.InfernoScythe>())
            {
                if (projectile.type == ProjectileID.DeathSickle && projectile.velocity.X < 0f)
                {
                    projectile.spriteDirection = -1;
                }
                projectile.rotation += projectile.direction * 0.05f;
                projectile.rotation += projectile.direction * 0.5f * (projectile.timeLeft / 180f);
                if (projectile.type == ProjectileID.DeathSickle)
                {
                    projectile.velocity *= 0.96f;
                }
                else
                {
                    projectile.velocity *= 0.95f;
                }
            }
            else
            {
                projectile.rotation += projectile.direction * 0.8f;
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 30f)
                {
                    if (projectile.ai[0] < 100f)
                    {
                        projectile.velocity *= 1.06f;
                    }
                    else
                    {
                        projectile.ai[0] = 200f;
                    }
                }
                for (var num305 = 0; num305 < 2; num305++)
                {
                    if (projectile.type == ProjectileID.DemonScythe)
                    {
                        var num306 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Shadowflame, 0f, 0f, 100, default(Color), 1f);
                        Main.dust[num306].noGravity = true;
                    }
                    else if (projectile.type == ModContent.ProjectileType<DevilScythe>())
                    {
                        var num307 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 1f);
                        Main.dust[num307].noGravity = true;
                    }
                    else if (projectile.type == ModContent.ProjectileType<TerraTyphoon>())
                    {
                        var num308 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.TerraBlade, 0f, 0f, 100, default(Color), 1f);
                        Main.dust[num308].noGravity = true;
                    }
                }
            }
        }
    }
}
