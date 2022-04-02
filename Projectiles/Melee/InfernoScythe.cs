using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles.Melee;

public class InfernoScythe : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Inferno Scythe");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Melee/InfernoScythe");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height;
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.timeLeft = 600;
        Projectile.light = 0.8f;
        Projectile.alpha = 10;
        Projectile.DamageType = DamageClass.Melee;
    }

    public override void AI()
    {
        if (Projectile.ai[1] == 0f && Projectile.type == ProjectileID.DemonSickle)
        {
            Projectile.ai[1] = 1f;
            SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 8);
        }
        if (Projectile.type == ProjectileID.IceSickle || Projectile.type == ProjectileID.DeathSickle || Projectile.type == ModContent.ProjectileType<InfernoScythe>())
        {
            if (Projectile.type == ProjectileID.DeathSickle && Projectile.velocity.X < 0f)
            {
                Projectile.spriteDirection = -1;
            }
            Projectile.rotation += Projectile.direction * 0.05f;
            Projectile.rotation += Projectile.direction * 0.5f * (Projectile.timeLeft / 180f);
            if (Projectile.type == ProjectileID.DeathSickle)
            {
                Projectile.velocity *= 0.96f;
            }
            else
            {
                Projectile.velocity *= 0.95f;
            }
        }
        else
        {
            Projectile.rotation += Projectile.direction * 0.8f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 30f)
            {
                if (Projectile.ai[0] < 100f)
                {
                    Projectile.velocity *= 1.06f;
                }
                else
                {
                    Projectile.ai[0] = 200f;
                }
            }
            for (var num305 = 0; num305 < 2; num305++)
            {
                if (Projectile.type == ProjectileID.DemonScythe)
                {
                    var num306 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Shadowflame, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[num306].noGravity = true;
                }
                else if (Projectile.type == ModContent.ProjectileType<DevilScythe>())
                {
                    var num307 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[num307].noGravity = true;
                }
                else if (Projectile.type == ModContent.ProjectileType<TerraTyphoon>())
                {
                    var num308 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.TerraBlade, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[num308].noGravity = true;
                }
            }
        }
    }
}