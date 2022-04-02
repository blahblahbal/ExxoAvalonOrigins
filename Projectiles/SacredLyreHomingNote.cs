using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class SacredLyreHomingNote : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Lyre Note");
    }
    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/SacredLyreHomingNote");
        Projectile.width = 16;
        Projectile.height = 16;
        Projectile.aiStyle = 21;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.light = 0.8f;
        Projectile.penetrate = -1;
        Projectile.friendly = true;
        Projectile.timeLeft = 840;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255, 150);
    }
    public override bool PreAI()
    {
        Lighting.AddLight(Projectile.position, 163 / 255, 77 / 255, 253 / 255);
        return true;
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        if (Projectile.type == ModContent.ProjectileType<SacredLyreHomingNote>())
        {
            //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
                
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 9f)
            {
                Projectile.position += Projectile.velocity;
                Projectile.Kill();
            }
            else
            {
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
            }
        }
        return false;
    }
    public override void AI()
    {
        int closest = Projectile.FindClosestNPC(16 * 15);
        if (closest != -1)
        {
            if (Main.npc[closest].lifeMax > 5 && !Main.npc[closest].friendly && !Main.npc[closest].townNPC)
            {
                Vector2 v = Main.npc[closest].position;
                if (Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, v, Main.npc[closest].width, Main.npc[closest].height))
                {
                    Projectile.velocity = Vector2.Normalize(v - Projectile.position) * 13f;
                }
            }
        }
    }
}