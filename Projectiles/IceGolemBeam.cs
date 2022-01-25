using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class IceGolemBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Golem Beam");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/IceGolemBeam");
            projectile.width = 2;
            projectile.height = 100;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.light = 1f;
            projectile.scale = 1f;
            projectile.timeLeft = 600;
            projectile.melee = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.penetrate == 1)
            {
                projectile.maxPenetrate = -1;
                projectile.penetrate = -1;

                int explosionArea = 60;
                Vector2 oldSize = projectile.Size;
                projectile.position = projectile.Center;
                projectile.Size += new Vector2(explosionArea);
                projectile.Center = projectile.position;

                projectile.tileCollide = false;
                projectile.velocity *= 0.01f;
                projectile.Damage();
                projectile.scale = 0.01f;

                projectile.position = projectile.Center;
                projectile.Size = new Vector2(10);
                projectile.Center = projectile.position;
            }

            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Dusts.SoulofFlight>(), 0, 0, 100, Color.Black, 0.8f);
                dust.noGravity = true;
                dust.velocity *= 1.5f;
                dust.scale *= 0.7f;
                dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Dusts.SoulofFlight>(), 0f, 0f, 100, Color.Black, 0.5f);
            }
            for (int i = 0; i < 10; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.IceBeamDust>(), 0f, 0f, 100, default(Color), 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 1.5f;
                Main.dust[dustIndex].scale *= 0.7f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.IceBeamDust>(), 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 1.5f;
                Main.dust[dustIndex].scale *= 0.7f;
            }
            for (int g = 0; g < 2; g++)
            {
                int gore1 = Main.rand.Next(3);
                if (gore1 == 0) gore1 = mod.GetGoreSlot("Gores/IcyExplosionGore1");
                if (gore1 == 1) gore1 = mod.GetGoreSlot("Gores/IcyExplosionGore2");
                if (gore1 == 2) gore1 = mod.GetGoreSlot("Gores/IcyExplosionGore3");
                int gore2 = Main.rand.Next(3);
                if (gore2 == 0) gore2 = mod.GetGoreSlot("Gores/IcyExplosionGore1");
                if (gore2 == 1) gore2 = mod.GetGoreSlot("Gores/IcyExplosionGore2");
                if (gore2 == 2) gore2 = mod.GetGoreSlot("Gores/IcyExplosionGore3");
                int gore3 = Main.rand.Next(3);
                if (gore3 == 0) gore3 = mod.GetGoreSlot("Gores/IcyExplosionGore1");
                if (gore3 == 1) gore3 = mod.GetGoreSlot("Gores/IcyExplosionGore2");
                if (gore3 == 2) gore3 = mod.GetGoreSlot("Gores/IcyExplosionGore3");
                int gore4 = Main.rand.Next(3);
                if (gore4 == 0) gore4 = mod.GetGoreSlot("Gores/IcyExplosionGore1");
                if (gore4 == 1) gore4 = mod.GetGoreSlot("Gores/IcyExplosionGore2");
                if (gore4 == 2) gore4 = mod.GetGoreSlot("Gores/IcyExplosionGore3");
                int goreIndex = Gore.NewGore(projectile.position, projectile.velocity, gore1);
                Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
                Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
                goreIndex = Gore.NewGore(projectile.position, projectile.velocity, gore2);
                Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
                Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
                goreIndex = Gore.NewGore(projectile.position, projectile.velocity, gore3);
                Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
                Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
                goreIndex = Gore.NewGore(projectile.position, projectile.velocity, gore4);
                Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
                Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
            }
            projectile.position.X = projectile.position.X + projectile.width / 2;
            projectile.position.Y = projectile.position.Y + projectile.height / 2;
            projectile.width = 100;
            projectile.height = 100;
            projectile.position.X = projectile.position.X - projectile.width / 2;
            projectile.position.Y = projectile.position.Y - projectile.height / 2;
            projectile.active = false;
        }
        public override void AI()
        {
            for (int i = 0; i < 4; i++)
            {
                int d = Dust.NewDust(projectile.Center, 8, 8, ModContent.DustType<Dusts.IceBeamDust>());
                Main.dust[d].noGravity = true;
            }
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}
