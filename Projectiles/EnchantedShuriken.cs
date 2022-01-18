using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class EnchantedShuriken : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Shuriken");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/EnchantedShuriken");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 6;
            projectile.ranged = true;
        }

        public override void AI()
        {
            projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.03f * projectile.direction;
            if (projectile.type == ModContent.ProjectileType<GuardianHammer2>())
            {
                if (projectile.ai[0] == 0f)
                {
                    Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 1);
                }
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 40f)
                {
                    if (projectile.ai[0] >= 60f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y + 0.2f;
                        projectile.velocity.X = projectile.velocity.X * 0.99f;
                    }
                    projectile.velocity.Y = projectile.velocity.Y + 0.2f;
                    projectile.velocity.X = projectile.velocity.X * 0.99f;
                }
            }
            else if (projectile.type == ModContent.ProjectileType<CorruptKnife>() || projectile.type == ModContent.ProjectileType<YuckyKnife>())
            {
                projectile.ai[0] += 1f;
                if (projectile.ai[0] < 30f)
                {
                    projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
                }
                if (projectile.type == ModContent.ProjectileType<YuckyKnife>())
                {
                    var num81 = ExxoAvalonOriginsGlobalNPC.FindClosest(projectile.position, 208f);
                    if (num81 != -1 && Main.npc[num81].lifeMax > 5 && !Main.npc[num81].friendly && !Main.npc[num81].townNPC)
                    {
                        var vector2 = Main.npc[num81].position;
                        if (Collision.CanHit(projectile.position, projectile.width, projectile.height, vector2, Main.npc[num81].width, Main.npc[num81].height))
                        {
                            projectile.velocity = Vector2.Normalize(vector2 - projectile.position) * 9f;
                        }
                    }
                }
            }
            else if (projectile.type == ModContent.ProjectileType<PhantomKnife>())
            {
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 30f)
                {
                    projectile.alpha += 10;
                    if (projectile.alpha >= 255)
                    {
                        projectile.active = false;
                    }
                }
                if (projectile.ai[0] < 30f)
                {
                    projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
                }
            }
            else if (projectile.type == ModContent.ProjectileType<Bones>())
            {
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 30f)
                {
                    projectile.velocity.Y = projectile.velocity.Y + 0.4f;
                    projectile.velocity.X = projectile.velocity.X * 0.97f;
                }
            }
            else
            {
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 20f)
                {
                    projectile.velocity.Y = projectile.velocity.Y + 0.4f;
                    projectile.velocity.X = projectile.velocity.X * 0.97f;
                }
                else if (projectile.type == ProjectileID.ThrowingKnife || projectile.type == ProjectileID.PoisonedKnife || projectile.type == ProjectileID.MagicDagger)
                {
                    projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
                }
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
            for (int i = 0; i < 15; i++)
            {
                var Sparkle = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 8, 8, DustID.MagicMirror, 0f, 0f, 100, default(Color), 1.25f);
                Main.dust[Sparkle].velocity *= 0.8f;
            }
            if (projectile.owner == Main.myPlayer)
            {
                // Drop a javelin item, 1 in 18 chance (~5.5% chance)
                Item.NewItem(projectile.getRect(), ModContent.ItemType<Items.Weapons.Throw.EnchantedShuriken>());
            }
        }
    }
}
