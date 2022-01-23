using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class SacredLyreHomingNote : ModProjectile
    {
        int timer = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lyre Note");
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/SacredLyreHomingNote");
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 21;
            projectile.magic = true;
            projectile.light = 0.8f;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 840;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 150);
        }
        public static int FindClosest(Vector2 pos, float dist)
        {
            int closest = -1;
            float last = dist;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC N = Main.npc[i];
                if (!N.active || N.townNPC || N.dontTakeDamage) continue;
                if (Vector2.Distance(pos, N.Center) < last)
                {
                    last = Vector2.Distance(pos, N.Center);
                    closest = i;
                }
                else continue;
            }
            return closest;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.type == ModContent.ProjectileType<SacredLyreHomingNote>())
            {
                //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
                
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 9f)
                {
                    projectile.position += projectile.velocity;
                    projectile.Kill();
                }
                else
                {
                    if (projectile.velocity.Y != oldVelocity.Y)
                    {
                        projectile.velocity.Y = -oldVelocity.Y;
                    }
                    if (projectile.velocity.X != oldVelocity.X)
                    {
                        projectile.velocity.X = -oldVelocity.X;
                    }
                }
            }
            return false;
        }
        public override void AI()
        {
            int closest = FindClosest(projectile.position, 16 * 15);
            if (closest != -1)
            {
                if (Main.npc[closest].lifeMax > 5 && !Main.npc[closest].friendly && !Main.npc[closest].townNPC)
                {
                    Vector2 v = Main.npc[closest].position;
                    if (Collision.CanHit(projectile.position, projectile.width, projectile.height, v, Main.npc[closest].width, Main.npc[closest].height))
                    {
                        projectile.velocity = Vector2.Normalize(v - projectile.position) * 13f;
                    }
                }
            }
        }
    }
}
