using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles
{
    public class Reflector : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reflector");
            Main.projFrames[projectile.type] = 20;
        }
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 36;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.minionSlots = 1f;
            projectile.timeLeft = 18000;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            projectile.tileCollide = false;
            //Main.projPet[projectile.type] = true;
        }
        public override void AI()
        {
            bool playerPosLessProj = false;
            bool playerPosGreaterProj = false;
            projectile.spriteDirection = Main.player[projectile.owner].direction;
            projectile.rotation = projectile.velocity.X * 0.075f;
            projectile.frameCounter++;
            if (projectile.frameCounter > 3)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 19)
            {
                projectile.frame = 0;
            }
            if (projectile.frame < 1)
            {
                projectile.frame = 0;
            }
            //if (Vector2.Distance(projectile.position, Main.player[projectile.owner].position) > 25 * 16)
            //{
            //    if (projectile.velocity.X == 0f || projectile.velocity.Y == 0f) projectile.tileCollide = false;
            //}
            //else projectile.tileCollide = true;

            Main.player[projectile.owner].AddBuff(ModContent.BuffType<Buffs.Reflector>(), 3600);
            if (projectile.type == ModContent.ProjectileType<Reflector>())
            {
                if (Main.player[projectile.owner].dead)
                {
                    Main.player[projectile.owner].GetModPlayer<ExxoAvalonOriginsModPlayer>().reflectorMinion = false;
                }
                if (Main.player[projectile.owner].GetModPlayer<ExxoAvalonOriginsModPlayer>().reflectorMinion)
                {
                    projectile.timeLeft = 2;
                }
            }
            
            int num321 = 10;
            int num322 = 40 * (projectile.minionPos + 1) * Main.player[projectile.owner].direction;
            if (Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) < projectile.position.X + (float)(projectile.width / 2) - num321 + num322)
            {
                playerPosLessProj = true;
            }
            else if (Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) > projectile.position.X + (float)(projectile.width / 2) + num321 + num322)
            {
                playerPosGreaterProj = true;
            }
            if (playerPosLessProj)
            {
                if (projectile.velocity.X > 0f)
                {
                    projectile.velocity.X = projectile.velocity.X * 0.94f;
                }
                projectile.velocity.X = projectile.velocity.X - 0.3f;
                if (projectile.velocity.X > 9f)
                {
                    projectile.velocity.X = 9f;
                }
            }
            else if (playerPosGreaterProj)
            {
                if (projectile.velocity.X < 0f)
                {
                    projectile.velocity.X = projectile.velocity.X * 0.94f;
                }
                projectile.velocity.X = projectile.velocity.X + 0.2f;
                if (projectile.velocity.X < -8f)
                {
                    projectile.velocity.X = -8f;
                }
            }
            if (playerPosLessProj || playerPosGreaterProj)
            {
                int num421 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
                int j2 = (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16;
                if (projectile.type == 236)
                {
                    num421 += projectile.direction;
                }
                if (playerPosLessProj)
                {
                    num421--;
                }
                if (playerPosGreaterProj)
                {
                    num421++;
                }
                num421 += (int)projectile.velocity.X;
            }
            //Collision.StepUp(ref projectile.position, ref projectile.velocity, projectile.width, projectile.height, ref projectile.stepSpeed, ref projectile.gfxOffY, 1, false);
            int closest = ExxoAvalonOriginsGlobalProjectile.FindClosestHostile(projectile.Center, 160f);
            if (closest != -1)
            {
                Projectile targ = Main.projectile[closest];
                projectile.velocity = Vector2.Normalize(targ.Center - projectile.Center) * 8f;
                if (Vector2.Distance(projectile.Center, targ.Center) < 160)
                {
                    Rectangle proj = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                    Rectangle targetProj = new Rectangle((int)targ.position.X, (int)targ.position.Y, targ.width, targ.height);
                    if (proj.Intersects(targetProj) && !targ.bobber && targ.type != 237 && targ.type != 238 && targ.type != 243 &&
                        targ.type != 244 && targ.type != 308 && targ.type != 295 && targ.type != 296 &&
                        targ.type != ProjectileID.PhantasmalDeathray && targ.type != ModContent.ProjectileType<Projectiles.Ghostflame>() &&
                        targ.type != ModContent.ProjectileType<Projectiles.WallofSteelLaser>() && targ.type != ModContent.ProjectileType<Projectiles.ElectricBolt>() &&
                        targ.type != ModContent.ProjectileType<Projectiles.HomingRocket>() && targ.type != ModContent.ProjectileType<Projectiles.StingerLaser>() &&
                        targ.type != ModContent.ProjectileType<Projectiles.CaesiumFireball>() && targ.type != ModContent.ProjectileType<Projectiles.CaesiumCrystal>())
                    {
                        targ.hostile = false;
                        targ.friendly = true;
                        targ.damage = (int)MathHelper.Clamp(targ.damage, targ.damage * 3, 150);
                        targ.velocity *= -1f;
                    }
                }
            }
            else
            {
                if (projectile.position.Y > Main.player[projectile.owner].Center.Y - 100)
                {
                    if (projectile.velocity.Y > 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y * 0.96f;
                    }
                    projectile.velocity.Y = projectile.velocity.Y - 0.3f;
                    if (projectile.velocity.Y > 6f)
                    {
                        projectile.velocity.Y = 6f;
                    }
                }
                else if (projectile.position.Y < Main.player[projectile.owner].Center.Y - 100)
                {
                    if (projectile.velocity.Y < 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y * 0.96f;
                    }
                    projectile.velocity.Y = projectile.velocity.Y + 0.2f;
                    if (projectile.velocity.Y < -6f)
                    {
                        projectile.velocity.Y = -6f;
                    }
                }
            }
        }
    }
}
