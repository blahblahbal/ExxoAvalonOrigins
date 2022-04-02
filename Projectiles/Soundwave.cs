using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class Soundwave : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Soundwave");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Soundwave");
        Projectile.width = 20;
        Projectile.height = 28;
        Projectile.scale = 1f;
        Projectile.aiStyle = -1;
        Projectile.timeLeft = 700;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
        Projectile.MaxUpdates = 2;
        Projectile.DamageType = DamageClass.Magic;
    }
    public override bool PreDraw(ref Color lightColor)
    {
        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, null, null);
        return true;
    }
    public override void PostDraw(Color lightColor)
    {
        Main.spriteBatch.End();
        Main.spriteBatch.Begin();
    }
    public override void AI()
    {
        Projectile.ai[0]++;
        if (Projectile.type == ModContent.ProjectileType<Soundwave>())
        {
            Projectile.scale = Math.Min(7f, 185.08197f * (float)Math.Pow(0.99111479520797729, Projectile.timeLeft));
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
            var v = Projectile.Center - new Vector2(Projectile.width * Projectile.scale / 2f, Projectile.height * Projectile.scale / 2f);
            var wH = new Vector2(Projectile.width * Projectile.scale, Projectile.height * Projectile.scale);
            var value2 = ExxoAvalonOrigins.NewRectVector2(v, wH);
            var npc = Main.npc;
            for (var num57 = 0; num57 < npc.Length; num57++)
            {
                var nPC = npc[num57];
                if (nPC.active && !nPC.dontTakeDamage && !nPC.friendly && nPC.life >= 1 && nPC.getRect().Intersects(value2))
                {
                    if (Projectile.ai[0] % 7 == 0) nPC.StrikeNPC(Projectile.damage, Projectile.knockBack, (nPC.Center.X < Projectile.Center.X) ? -1 : 1, false, false);
                }
            }
        }
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
}
