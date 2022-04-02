using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles.Summon;

public class IceGolemBeam : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ice Golem Beam");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Summon/IceGolemBeam");
        Projectile.width = 2;
        Projectile.height = 100;
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.light = 1f;
        Projectile.scale = 1f;
        Projectile.timeLeft = 600;
        Projectile.DamageType = DamageClass.Melee;
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.Kill();
        return true;
    }
    public override void Kill(int timeLeft)
    {
        if (Projectile.penetrate == 1)
        {
            Projectile.maxPenetrate = -1;
            Projectile.penetrate = -1;

            int explosionArea = 60;
            Vector2 oldSize = Projectile.Size;
            Projectile.position = Projectile.Center;
            Projectile.Size += new Vector2(explosionArea);
            Projectile.Center = Projectile.position;

            Projectile.tileCollide = false;
            Projectile.velocity *= 0.01f;
            Projectile.Damage();
            Projectile.scale = 0.01f;

            Projectile.position = Projectile.Center;
            Projectile.Size = new Vector2(10);
            Projectile.Center = Projectile.position;
        }

        SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        for (int i = 0; i < 10; i++)
        {
            Dust dust = Dust.NewDustDirect(Projectile.position - Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Dusts.SoulofFlight>(), 0, 0, 100, Color.Black, 0.8f);
            dust.noGravity = true;
            dust.velocity *= 1.5f;
            dust.scale *= 0.7f;
            dust = Dust.NewDustDirect(Projectile.position - Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Dusts.SoulofFlight>(), 0f, 0f, 100, Color.Black, 0.5f);
        }
        for (int i = 0; i < 10; i++)
        {
            int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<Dusts.IceBeamDust>(), 0f, 0f, 100, default(Color), 3f);
            Main.dust[dustIndex].noGravity = true;
            Main.dust[dustIndex].velocity *= 1.5f;
            Main.dust[dustIndex].scale *= 0.7f;
            dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<Dusts.IceBeamDust>(), 0f, 0f, 100, default(Color), 2f);
            Main.dust[dustIndex].velocity *= 1.5f;
            Main.dust[dustIndex].scale *= 0.7f;
        }
        for (int g = 0; g < 2; g++)
        {
            int gore1 = Main.rand.Next(3);
            if (gore1 == 0) gore1 = Mod.Find<ModGore>("Gores/IcyExplosionGore1");
            if (gore1 == 1) gore1 = Mod.Find<ModGore>("Gores/IcyExplosionGore2");
            if (gore1 == 2) gore1 = Mod.Find<ModGore>("Gores/IcyExplosionGore3");
            int gore2 = Main.rand.Next(3);
            if (gore2 == 0) gore2 = Mod.Find<ModGore>("Gores/IcyExplosionGore1");
            if (gore2 == 1) gore2 = Mod.Find<ModGore>("Gores/IcyExplosionGore2");
            if (gore2 == 2) gore2 = Mod.Find<ModGore>("Gores/IcyExplosionGore3");
            int gore3 = Main.rand.Next(3);
            if (gore3 == 0) gore3 = Mod.Find<ModGore>("Gores/IcyExplosionGore1");
            if (gore3 == 1) gore3 = Mod.Find<ModGore>("Gores/IcyExplosionGore2");
            if (gore3 == 2) gore3 = Mod.Find<ModGore>("Gores/IcyExplosionGore3");
            int gore4 = Main.rand.Next(3);
            if (gore4 == 0) gore4 = Mod.Find<ModGore>("Gores/IcyExplosionGore1");
            if (gore4 == 1) gore4 = Mod.Find<ModGore>("Gores/IcyExplosionGore2");
            if (gore4 == 2) gore4 = Mod.Find<ModGore>("Gores/IcyExplosionGore3");
            int goreIndex = Gore.NewGore(Projectile.position, Projectile.velocity, gore1);
            Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
            Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
            goreIndex = Gore.NewGore(Projectile.position, Projectile.velocity, gore2);
            Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
            Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
            goreIndex = Gore.NewGore(Projectile.position, Projectile.velocity, gore3);
            Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
            Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
            goreIndex = Gore.NewGore(Projectile.position, Projectile.velocity, gore4);
            Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
            Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
        }
        Projectile.position.X = Projectile.position.X + Projectile.width / 2;
        Projectile.position.Y = Projectile.position.Y + Projectile.height / 2;
        Projectile.width = 100;
        Projectile.height = 100;
        Projectile.position.X = Projectile.position.X - Projectile.width / 2;
        Projectile.position.Y = Projectile.position.Y - Projectile.height / 2;
        Projectile.active = false;
    }
    public override void AI()
    {
        for (int i = 0; i < 4; i++)
        {
            int d = Dust.NewDust(Projectile.Center, 8, 8, ModContent.DustType<Dusts.IceBeamDust>());
            Main.dust[d].noGravity = true;
        }
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
}