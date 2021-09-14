using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles
{
	public class CaesiumFireball : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Caesium Fireball");
		}

		public override void SetDefaults()
		{
            projectile.width = 28;
            projectile.height = 28;
			projectile.aiStyle = -1;
			projectile.melee = true;
			projectile.alpha = 0;
			projectile.friendly = false;
            projectile.hostile = true;
		}
        public override void AI()
        {
            projectile.rotation++;
            for (var num917 = 0; num917 < 5; num917++)
            {
                var num918 = projectile.velocity.X / 3f * num917;
                var num919 = projectile.velocity.Y / 3f * num917;
                var num920 = 4;
                var num921 = Dust.NewDust(new Vector2(projectile.position.X + num920, projectile.position.Y + num920), projectile.width - num920 * 2, projectile.height - num920 * 2, ModContent.DustType<Dusts.CaesiumDust>(), 0f, 0f, 100, default, 1.2f);
                Main.dust[num921].noGravity = true;
                Main.dust[num921].velocity *= 0.1f;
                Main.dust[num921].velocity += projectile.velocity * 0.1f;
                var dust105 = Main.dust[num921];
                dust105.position.X = dust105.position.X - num918;
                var dust106 = Main.dust[num921];
                dust106.position.Y = dust106.position.Y - num919;
            }
        }
        public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Fireball"));
            projectile.damage <<= 1;
            projectile.penetrate = 10;
            projectile.width <<= 3;
            projectile.height <<= 3;
            projectile.Damage();
            for (int i = 0; i < 30; i++)
            {
                float velX = 2f - ((float)Main.rand.Next(20)) / 5f;
                float velY = 2f - ((float)Main.rand.Next(20)) / 5f;
                velX *= 4f;
                velY *= 4f;
                int p = Dust.NewDust(new Vector2(projectile.position.X - (float)(projectile.width >> 1), projectile.position.Y - (float)(projectile.height >> 1)), projectile.width, projectile.height, ModContent.DustType<Dusts.CaesiumDust>(), velX, velY, 160, default, 1.5f);
                Dust.NewDust(new Vector2(projectile.position.X - (float)(projectile.width >> 1), projectile.position.Y - (float)(projectile.height >> 1)), projectile.width, projectile.height, DustID.CursedTorch, velX, velY, 160, default, 1.5f);
            }
            //for (int num949 = 4; num949 < 31; num949++)
            //{
            //    float num950 = projectile.oldVelocity.X * (30f / (float)num949);
            //    float num951 = projectile.oldVelocity.Y * (30f / (float)num949);
            //    int num952 = Dust.NewDust(new Vector2(projectile.oldPosition.X - num950, projectile.oldPosition.Y - num951), 8, 8, DustID.CursedTorch, projectile.oldVelocity.X, projectile.oldVelocity.Y, 255, default, 1.8f);
            //    Main.dust[num952].noGravity = true;
            //    Dust dust = Main.dust[num952];
            //    dust.velocity *= 0.5f;
            //    num952 = Dust.NewDust(new Vector2(projectile.oldPosition.X - num950, projectile.oldPosition.Y - num951), 8, 8, ModContent.DustType<Dusts.CaesiumDust>(), projectile.oldVelocity.X, projectile.oldVelocity.Y, 255, default, 1.4f);
            //    dust = Main.dust[num952];
            //    dust.velocity *= 0.05f;
            //    Main.dust[num952].noGravity = true;
            //}
        }
	}
}