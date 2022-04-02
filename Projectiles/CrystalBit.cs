using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class CrystalBit : ModProjectile
{
    int rn = 0;
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Crystal Shard");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/CrystalBit");
        Projectile.aiStyle = -1;
        Projectile.width = 20;
        Projectile.height = 20;
        Projectile.tileCollide = false;
        Projectile.penetrate = -1;
        Projectile.hostile = true;
        Projectile.timeLeft = 180;
        Projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
        rn = Main.rand.Next(60, 121);
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.velocity.X = oldVelocity.X * -0.02f;
        if (Projectile.velocity.X != oldVelocity.X)
        {
            Projectile.velocity.X = oldVelocity.X * -0.5f;
        }
        if (Projectile.velocity.Y != oldVelocity.Y && oldVelocity.Y > 1f)
        {
            Projectile.velocity.Y = oldVelocity.Y * -0.5f;
        }
        return false;
    }
    public override void AI()
    {
        Projectile.hostile = true;
        Projectile.friendly = false;
        Projectile.velocity *= 0.85f;
        Projectile.rotation = (float)System.Math.Atan2(Projectile.Center.Y - Main.player[Player.FindClosest(Projectile.position, Projectile.width, Projectile.height)].Center.Y, Projectile.Center.X - Main.player[Player.FindClosest(Projectile.position, Projectile.width, Projectile.height)].Center.X) - 1.57079633f;
        Projectile.ai[0]++;
        if (Projectile.ai[0] > rn)
        {
            SoundEngine.PlaySound(2, Projectile.position, 43);
            int p = Projectile.NewProjectile(Projectile.GetItemSource_FromThis(), Projectile.position, Projectile.velocity, ModContent.ProjectileType<CrystalBeam>(), 67, Projectile.knockBack, Main.myPlayer);
            Main.projectile[p].velocity = Vector2.Normalize(Main.player[Player.FindClosest(Projectile.position, Projectile.width, Projectile.height)].position - Projectile.position) * 7f;
            Projectile.active = false;
        }
    }
}
