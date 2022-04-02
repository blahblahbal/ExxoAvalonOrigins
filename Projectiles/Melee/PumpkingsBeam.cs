using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles.Melee;

public class PumpkingsBeam : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Pumpking's Beam");
    }
    public override void SetDefaults()
    {
        Projectile.width = 16;
        Projectile.height = 16;
        Projectile.aiStyle = 27;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.penetrate = 1;
        Projectile.friendly = true;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        if (this.Projectile.localAI[1] >= 15f)
        {
            return new Color(255, 255, 255, this.Projectile.alpha);
        }
        if (this.Projectile.localAI[1] < 5f)
        {
            return Color.Transparent;
        }
        int num7 = (int)((this.Projectile.localAI[1] - 5f) / 10f * 255f);
        return new Color(num7, num7, num7, num7);
    }
    public override void AI()
    {
        if (Projectile.type == ModContent.ProjectileType<PumpkingsBeam>())
        {
            var num974 = ExxoAvalonOriginsGlobalNPC.FindClosest(Projectile.position, 320f);
            if (num974 != -1 && Main.npc[num974].lifeMax > 5 && !Main.npc[num974].friendly && !Main.npc[num974].townNPC)
            {
                var vector76 = Main.npc[num974].position;
                if (Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, vector76, Main.npc[num974].width, Main.npc[num974].height))
                {
                    Projectile.velocity = Vector2.Normalize(vector76 - Projectile.position) * 9f;
                }
            }
        }
        if (Projectile.localAI[1] > 7f)
        {
            int num209 = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 2f - Projectile.velocity.Y * 4f), 8, 8, DustID.Torch, 0f, 0f, 100, default(Color), 1.8f);
            Dust dust = Main.dust[num209];
            dust.velocity *= 0.2f;
            dust.noGravity = true;
        }
    }
    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
        for (int num394 = 4; num394 < 24; num394++)
        {
            float num395 = Projectile.oldVelocity.X * (30f / (float)num394);
            float num396 = Projectile.oldVelocity.Y * (30f / (float)num394);
            int num209 = Dust.NewDust(new Vector2(Projectile.position.X - num395, Projectile.position.Y - num396), 8, 8, DustID.Torch, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, 100, default(Color), 1.8f);
            Dust dust = Main.dust[num209];
            dust.velocity *= 1.5f;
            dust.noGravity = true;
        }
    }
}