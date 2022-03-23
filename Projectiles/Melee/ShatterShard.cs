using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee
{
    public class ShatterShard : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shatter Shard");
        }
        public override void SetDefaults()
        {
            projectile.penetrate = 1;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.timeLeft = 45;
            projectile.scale = 1.2f;
        }
        public override void AI()
        {
            projectile.spriteDirection = projectile.direction;
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(2) == 0)
            {
                int num239 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 18, 18, 70, -0.5f, -0.5f, default, default, 1f);
                Dust dust30 = Main.dust[num239];
                dust30.noGravity = true;
            }
        }
        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            int size = 10;
            hitbox.X -= size;
            hitbox.Y -= size;
            hitbox.Width += size * 2;
            hitbox.Height += size * 2;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 150);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 27, 0.8f, -0.25f);
            for (int num237 = 0; num237 < 10; num237++)
            {
                int num239 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 18, 18, 70, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f, default, default, 1.2f);
                Dust dust30 = Main.dust[num239];
                dust30.noGravity = true;
            }
            for (int num237 = 0; num237 < 10; num237++)
            {
                int num239 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 18, 18, 70, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f, default, default, 1.2f);
                Dust dust30 = Main.dust[num239];
                dust30.noGravity = true;
            }
        }
    }
}
