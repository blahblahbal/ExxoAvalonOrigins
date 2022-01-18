using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class PumpkingsBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pumpking's Beam");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 27;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.friendly = true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (this.projectile.localAI[1] >= 15f)
            {
                return new Color(255, 255, 255, this.projectile.alpha);
            }
            if (this.projectile.localAI[1] < 5f)
            {
                return Color.Transparent;
            }
            int num7 = (int)((this.projectile.localAI[1] - 5f) / 10f * 255f);
            return new Color(num7, num7, num7, num7);
        }
        public override void AI()
        {
            if (projectile.type == ModContent.ProjectileType<PumpkingsBeam>())
            {
                var num974 = ExxoAvalonOriginsGlobalNPC.FindClosest(projectile.position, 320f);
                if (num974 != -1 && Main.npc[num974].lifeMax > 5 && !Main.npc[num974].friendly && !Main.npc[num974].townNPC)
                {
                    var vector76 = Main.npc[num974].position;
                    if (Collision.CanHit(projectile.position, projectile.width, projectile.height, vector76, Main.npc[num974].width, Main.npc[num974].height))
                    {
                        projectile.velocity = Vector2.Normalize(vector76 - projectile.position) * 9f;
                    }
                }
            }
            if (projectile.localAI[1] > 7f)
            {
                int num209 = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 4f + 2f, projectile.position.Y + 2f - projectile.velocity.Y * 4f), 8, 8, DustID.Fire, 0f, 0f, 100, default(Color), 1.8f);
                Dust dust = Main.dust[num209];
                dust.velocity *= 0.2f;
                dust.noGravity = true;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
            for (int num394 = 4; num394 < 24; num394++)
            {
                float num395 = projectile.oldVelocity.X * (30f / (float)num394);
                float num396 = projectile.oldVelocity.Y * (30f / (float)num394);
                int num209 = Dust.NewDust(new Vector2(projectile.position.X - num395, projectile.position.Y - num396), 8, 8, DustID.Fire, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f, 100, default(Color), 1.8f);
                Dust dust = Main.dust[num209];
                dust.velocity *= 1.5f;
                dust.noGravity = true;
            }
        }
    }
}