using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class DarkMatterFireball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Matter Fireball");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/DarkMatterFireball");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.tileCollide = true;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.timeLeft = 100;
            projectile.light = 1f;
            projectile.penetrate = -1;
            projectile.magic = true;
            projectile.ignoreWater = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
            return true;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(2) == 0) target.AddBuff(ModContent.BuffType<Buffs.DarkInferno>(), 240);
        }
        public override void AI()
        {
            int num40 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, DustID.Wraith, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f);
            int D3 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, DustID.Enchanted_Pink, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f);
            Main.dust[num40].noGravity = true;
            Main.dust[D3].noGravity = true;
            if (Main.rand.Next(10) == 0)
            {
                num40 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Wraith, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.4f);
                D3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Enchanted_Pink, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.4f);
            }
            if (projectile.ai[1] >= 20f)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            }
            projectile.rotation += 0.3f * (float)projectile.direction;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}