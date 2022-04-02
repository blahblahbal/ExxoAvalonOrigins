using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class BloodyArrow : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bloody Arrow");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/BloodyArrow");
        Projectile.width = dims.Width * 10 / 32;
        Projectile.height = dims.Height * 10 / 32 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        AIType = 636;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.Ranged;
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        Projectile.ai[0] = 1;
        Projectile.ai[1] = target.whoAmI;
        Projectile.Kill();
        //projectile.velocity *= 0f;
        //projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().bloodArrowPos = projectile.position;
        target.AddBuff(ModContent.BuffType<Buffs.Bleeding>(), 8 * 60);
        //if (target.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().bleedStacks < 3)
        //{
        //    target.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().bleedStacks++;
        //}
    }
    public override void AI()
    {
        Projectile.ai[0] += 1f;
        if (Projectile.ai[0] >= 15f)
        {
            Projectile.ai[0] = 15f;
            Projectile.velocity.Y = Projectile.velocity.Y + 0.1f;
        }
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
}
