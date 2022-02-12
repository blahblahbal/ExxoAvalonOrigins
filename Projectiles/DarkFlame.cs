using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class DarkFlame : ModProjectile
    {
        float theta; // this code and everything using it is referenced from Laugicality (The Enigma Mod) by Laugic
        float distanceFromOrigin;
        float speed;
        Vector2 origin;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Flame");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/DarkFlame");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.light = 0.8f;
            projectile.alpha = 50;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.scale = 0.9f;

            theta = -1;
            distanceFromOrigin = 0;
            speed = 1;
        }

        public override void AI()
        {
            var num150 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, DustID.Enchanted_Pink, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f);
            Main.dust[num150].noGravity = true;
            var num151 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, DustID.Ash, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f);
            Main.dust[num151].noGravity = true;
            if (projectile.ai[1] >= 20f)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            }
            projectile.rotation += 0.3f * projectile.direction;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Buffs.DarkInferno>(), 240);
        }
    }
}