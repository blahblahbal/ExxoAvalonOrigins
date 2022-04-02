using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class ClownBomb : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Clown Bomb");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/ClownBomb");
        Projectile.width = dims.Width * 20 / 20;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.light = 0.9f;
        Projectile.alpha = 0;
        Projectile.scale = 1f;
        Projectile.timeLeft = 240;
        AIType = 30;
        Projectile.tileCollide = true;
        Projectile.CloneDefaults(30);
    }

    public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
    {
        fallThrough = false;
        return true;
    }
    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        for (int i = 0; i < 15; i++)
        {
            int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
            Dust obj = Main.dust[dustIndex];
            obj.velocity *= 1.4f;
        }
        for (int j = 0; j < 10; j++)
        {
            int dustIndex2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
            Main.dust[dustIndex2].noGravity = true;
            Dust obj2 = Main.dust[dustIndex2];
            obj2.velocity *= 5f;
            dustIndex2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
            Dust obj3 = Main.dust[dustIndex2];
            obj3.velocity *= 3f;
        }
        if (Main.myPlayer != Projectile.owner)
        {
            return;
        }
    }
}
