using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class NaquadahDrill : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naquadah Drill");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/NaquadahDrill");
            projectile.width = dims.Width;
            projectile.height = dims.Height * 26 / 58 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.scale = 1.2f;
        }

        public override void AI()
        {
            if (projectile.type == ProjectileID.ChlorophyteJackhammer)
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 4)
                {
                    projectile.frameCounter = 0;
                    projectile.frame++;
                }
                if (projectile.frame > 3)
                {
                    projectile.frame = 0;
                }
            }
            if (projectile.soundDelay <= 0)
            {
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 22);
                projectile.soundDelay = 30;
            }
            if (Main.myPlayer == projectile.owner)
            {
                if (Main.player[projectile.owner].channel)
                {
                    var num316 = Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].shootSpeed * projectile.scale;
                    var vector22 = new Vector2(Main.player[projectile.owner].position.X + Main.player[projectile.owner].width * 0.5f, Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height * 0.5f);
                    var num317 = Main.mouseX + Main.screenPosition.X - vector22.X;
                    var num318 = Main.mouseY + Main.screenPosition.Y - vector22.Y;
                    if (Main.player[projectile.owner].gravDir == -1f)
                    {
                        num318 = Main.screenHeight - Main.mouseY + Main.screenPosition.Y - vector22.Y;
                    }
                    var num319 = (float)Math.Sqrt(num317 * num317 + num318 * num318);
                    num319 = (float)Math.Sqrt(num317 * num317 + num318 * num318);
                    num319 = num316 / num319;
                    num317 *= num319;
                    num318 *= num319;
                    if (num317 != projectile.velocity.X || num318 != projectile.velocity.Y)
                    {
                        projectile.netUpdate = true;
                    }
                    projectile.velocity.X = num317;
                    projectile.velocity.Y = num318;
                }
                else
                {
                    projectile.Kill();
                }
            }
            if (projectile.velocity.X > 0f)
            {
                Main.player[projectile.owner].ChangeDir(1);
            }
            else if (projectile.velocity.X < 0f)
            {
                Main.player[projectile.owner].ChangeDir(-1);
            }
            projectile.spriteDirection = projectile.direction;
            Main.player[projectile.owner].ChangeDir(projectile.direction);
            Main.player[projectile.owner].heldProj = projectile.whoAmI;
            Main.player[projectile.owner].itemTime = 2;
            Main.player[projectile.owner].itemAnimation = 2;
            projectile.position.X = Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 - projectile.width / 2;
            projectile.position.Y = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - projectile.height / 2;
            projectile.rotation = (float)(Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.5700000524520874);
            if (Main.player[projectile.owner].direction == 1)
            {
                Main.player[projectile.owner].itemRotation = (float)Math.Atan2(projectile.velocity.Y * projectile.direction, projectile.velocity.X * projectile.direction);
            }
            else
            {
                Main.player[projectile.owner].itemRotation = (float)Math.Atan2(projectile.velocity.Y * projectile.direction, projectile.velocity.X * projectile.direction);
            }
            projectile.velocity.X = projectile.velocity.X * (1f + Main.rand.Next(-3, 4) * 0.01f);
            if (Main.rand.Next(6) == 0)
            {
                var num320 = Dust.NewDust(projectile.position + (projectile.velocity * Main.rand.Next(6, 10)) * 0.1f, projectile.width, projectile.height, DustID.Smoke, 0f, 0f, 80, default(Color), 1.4f);
                var dust52 = Main.dust[num320];
                dust52.position.X = dust52.position.X - 4f;
                Main.dust[num320].noGravity = true;
                Main.dust[num320].velocity *= 0.2f;
                Main.dust[num320].velocity.Y = -Main.rand.Next(7, 13) * 0.15f;
            }
        }
    }
}