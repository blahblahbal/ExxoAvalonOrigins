using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles.Melee
{
    public class BlahBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah Beam");
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Melee/BlahBeam");
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 27;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 2;
            Projectile.light = 0.8f;
            Projectile.penetrate = 2;
            Projectile.alpha = 255;
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
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int randomNum = Main.rand.Next(7);
            if (randomNum == 0) target.AddBuff(20, 300);
            else if (randomNum == 1) target.AddBuff(24, 200);
            else if (randomNum == 2) target.AddBuff(31, 120);
            else if (randomNum == 3) target.AddBuff(39, 300);
            else if (randomNum == 4) target.AddBuff(44, 300);
            else if (randomNum == 5) target.AddBuff(70, 240);
            else if (randomNum == 6) target.AddBuff(69, 300);
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
            if (Projectile.type == ModContent.ProjectileType<BlahBeam>())
            {
                SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
                Projectile.ai[0] += 1f;
                if (Projectile.ai[0] >= 4f)
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
            int closest = Projectile.FindClosestNPC(16 * 20);
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
            if (Projectile.localAI[1] > 7f)
            {
                var num483 = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 2f - Projectile.velocity.Y * 4f), 8, 8, DustID.Torch, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default(Color), 1.5f);
                Main.dust[num483].velocity *= -0.25f;
                Main.dust[num483].noGravity = true;
                num483 = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 2f - Projectile.velocity.Y * 4f), 8, 8, DustID.Torch, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default(Color), 1.5f);
                Main.dust[num483].velocity *= -0.25f;
                Main.dust[num483].position -= Projectile.velocity * 0.5f;
                Main.dust[num483].noGravity = true;
            }
        }
    }
}
