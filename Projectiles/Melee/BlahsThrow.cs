using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee;

public class BlahsThrow : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blah's Throw");
        ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1;
        ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 450f;
        ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 20f;
    }

    public override void SetDefaults()
    {
        Projectile.extraUpdates = 0;
        Projectile.width = 16;
        Projectile.height = 16;
        Projectile.aiStyle = 99;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.scale = 1f;
        //drawOriginOffsetX = -6;
        //DrawOriginOffsetY = -6;
        //DrawOffsetX = -6;
    }

    public override void PostAI()
    {
        //projectile.rotation++;
        if (Main.rand.NextBool())
        {
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
            dust.noGravity = true;
            dust.scale = 1.6f;
        }
    }
}