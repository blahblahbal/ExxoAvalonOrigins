using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class ImpactBolt : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Impact Bolt");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/ImpactBolt");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.hostile = true;
        Projectile.tileCollide = false;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.MaxUpdates = 100;
        Projectile.timeLeft = 100;
    }
    public override void OnHitPlayer(Player target, int damage, bool crit)
    {
        target.immuneTime = 14;
    }
    public override bool PreAI()
    {
        Lighting.AddLight(Projectile.position, 2 / 255, 254 / 255, 201 / 255);
        return true;
    }
    public override void AI()
    {
        if (Projectile.type == ModContent.ProjectileType<ImpactBolt>())
        {
            for (var num613 = 0; num613 < 4; num613++)
            {
                var value10 = Projectile.position;
                value10 -= Projectile.velocity * num613 * 0.25f;
                Projectile.alpha = 255;
                var num614 = Dust.NewDust(value10, 1, 1, DustID.MagnetSphere, 0f, 0f, 0, default, 1f);
                Main.dust[num614].position = value10;
                var dust65 = Main.dust[num614];
                dust65.position.X = dust65.position.X + Projectile.width / 2;
                var dust66 = Main.dust[num614];
                dust66.position.Y = dust66.position.Y + Projectile.height / 2;
                Main.dust[num614].scale = Main.rand.Next(70, 110) * 0.013f;
                Main.dust[num614].velocity *= 0.2f;
            }
        }
    }
}