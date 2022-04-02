using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

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
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.hostile = true;
        Projectile.light = 0.8f;
        Projectile.alpha = 50;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.penetrate = -1;
        Projectile.scale = 0.9f;

        theta = -1;
        distanceFromOrigin = 0;
        speed = 1;
    }

    public override void AI()
    {
        var num150 = Dust.NewDust(new Vector2(Projectile.position.X + Projectile.velocity.X, Projectile.position.Y + Projectile.velocity.Y), Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), 1f);
        Main.dust[num150].noGravity = true;
        var num151 = Dust.NewDust(new Vector2(Projectile.position.X + Projectile.velocity.X, Projectile.position.Y + Projectile.velocity.Y), Projectile.width, Projectile.height, DustID.Ash, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), 1f);
        Main.dust[num151].noGravity = true;
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

    public override void OnHitPlayer(Player target, int damage, bool crit)
    {
        target.AddBuff(ModContent.BuffType<Buffs.DarkInferno>(), 240);
    }
}