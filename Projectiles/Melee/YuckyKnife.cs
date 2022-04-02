using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee;

public class YuckyKnife : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Yucky Knife");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Melee/YuckyKnife");
        Projectile.width = dims.Width * 8 / 30;
        Projectile.height = dims.Height * 8 / 30 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.penetrate = 1;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.light = 0.6f;
        Projectile.ignoreWater = true;
        Projectile.extraUpdates = 0;
        Projectile.timeLeft = 300;
    }

    public override void AI()
    {
        Projectile.rotation += (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y)) * 0.03f * Projectile.direction;
        Projectile.ai[0] += 1f;
        if (Projectile.ai[0] < 30f)
        {
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        }
        var num81 = ExxoAvalonOriginsGlobalNPC.FindClosest(Projectile.position, 208f);
        if (num81 != -1 && Main.npc[num81].lifeMax > 5 && !Main.npc[num81].friendly && !Main.npc[num81].townNPC)
        {
            var vector2 = Main.npc[num81].position;
            if (Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, vector2, Main.npc[num81].width, Main.npc[num81].height))
            {
                Projectile.velocity = Vector2.Normalize(vector2 - Projectile.position) * 9f;
            }
        }
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
}