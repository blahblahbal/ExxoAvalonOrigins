using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class DarkMatterFireball : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dark Matter Fireball");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/DarkMatterFireball");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.tileCollide = true;
        Projectile.friendly = false;
        Projectile.hostile = true;
        Projectile.timeLeft = 100;
        Projectile.light = 1f;
        Projectile.penetrate = -1;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.ignoreWater = true;
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
        return true;
    }
    public override void OnHitPlayer(Player target, int damage, bool crit)
    {
        if (Main.rand.Next(2) == 0) target.AddBuff(ModContent.BuffType<Buffs.DarkInferno>(), 240);
    }
    public override void AI()
    {
        int num40 = Dust.NewDust(new Vector2(Projectile.position.X + Projectile.velocity.X, Projectile.position.Y + Projectile.velocity.Y), Projectile.width, Projectile.height, DustID.Wraith, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), 3f);
        int D3 = Dust.NewDust(new Vector2(Projectile.position.X + Projectile.velocity.X, Projectile.position.Y + Projectile.velocity.Y), Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), 3f);
        Main.dust[num40].noGravity = true;
        Main.dust[D3].noGravity = true;
        if (Main.rand.Next(10) == 0)
        {
            num40 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Wraith, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), 1.4f);
            D3 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), 1.4f);
        }
        if (Projectile.ai[1] >= 20f)
        {
            Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
        }
        Projectile.rotation += 0.3f * (float)Projectile.direction;
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
}