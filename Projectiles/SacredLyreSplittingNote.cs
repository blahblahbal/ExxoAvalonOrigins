using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class SacredLyreSplittingNote : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Lyre Note");
    }
    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/SacredLyreSplittingNote");
        Projectile.width = 16;
        Projectile.height = 16;
        Projectile.aiStyle = 21;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.light = 0.8f;
        Projectile.penetrate = -1;
        Projectile.friendly = true;
        Projectile.timeLeft = 840;
    }
    public override bool PreAI()
    {
        Lighting.AddLight(Projectile.position, 72 / 255, 135 / 255, 255 / 255);
        return true;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255, 150);
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        if (Projectile.type == ModContent.ProjectileType<SacredLyreSplittingNote>())
        {
            //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
            for (int num133 = 0; num133 < 3; num133++)
            {
                float num134 = -Projectile.velocity.X * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
                float num135 = -Projectile.velocity.Y * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
                int proj = Projectile.NewProjectile(Projectile.position.X + num134, Projectile.position.Y + num135, num134, num135, ProjectileID.CrystalShard, (int)(Projectile.damage * 0.65f), 0f, Projectile.owner, 0f, 0f);
                // Main.projectile[proj].ranged = false /* tModPorter - this is redundant, for more info see https://github.com/tModLoader/tModLoader/wiki/Update-Migration-Guide#damage-classes */ ;
                Main.projectile[proj].DamageType = DamageClass.Magic;
            }
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
}