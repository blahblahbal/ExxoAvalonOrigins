using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class Ghostflame : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ghostflame");
    }

    public override void SetDefaults()
    {
        Projectile.width = 16;
        Projectile.height = 16;
        Projectile.aiStyle = -1;
        Projectile.tileCollide = false;
        Projectile.friendly = false;
        Projectile.hostile = true;
        Projectile.timeLeft = 100;
        Projectile.light = 1f;
        Projectile.penetrate = -1;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.ignoreWater = true;
        Projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
    }
    public override void OnHitPlayer(Player target, int damage, bool crit)
    {
        if (Main.rand.Next(2) == 0) target.AddBuff(ModContent.BuffType<Buffs.ShadowCurse>(), 240);
    }
    public override void AI()
    {
        int num890 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonSpirit, 0f, 0f, 0, default(Color), 1f);
        Main.dust[num890].velocity *= 0.1f;
        Main.dust[num890].scale = 1.3f;
        Main.dust[num890].noGravity = true;
        if (Projectile.ai[1] >= 20f)
        {
            Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
        }
        Projectile.rotation += 0.3f * Projectile.direction;
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
}