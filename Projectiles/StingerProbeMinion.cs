using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles
{
    public class StingerProbeMinion : ModProjectile
    {
        float rotTimer;
        int projTimer;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stinger Probe");
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/StingerProbeMinion");
            projectile.width = dims.Width;
            projectile.height = dims.Height;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.light = 0.3f;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 60;

            rotTimer = 1;
        }

        public override bool? CanCutTiles() { return false; }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];

            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<Buffs.StingerProbe>());
            }

            if (player.HasBuff(ModContent.BuffType<Buffs.StingerProbe>()))
            {
                projectile.timeLeft = 2;
            }

            #region reflect
            // yoinked from reflex charm
            var projWS = new Rectangle((int)projectile.Center.X - 32, (int)projectile.Center.Y - 32, 64, 64);
            foreach (Projectile Pr in Main.projectile)
            {
                if (!Pr.friendly && !Pr.bobber && Pr.type != ProjectileID.RainCloudMoving && Pr.type != ProjectileID.RainCloudRaining &&
                    Pr.type != ProjectileID.BloodCloudMoving && Pr.type != ProjectileID.BloodCloudRaining && Pr.type != 50 && Pr.type != ProjectileID.Stinger && Pr.type != 53 && Pr.type != 358 &&
                    Pr.type != ProjectileID.FrostHydra && Pr.type != ProjectileID.InfernoFriendlyBolt &&
                    Pr.type != ProjectileID.InfernoFriendlyBlast && Pr.type != ProjectileID.FlyingPiggyBank &&
                    Pr.type != ProjectileID.PhantasmalDeathray && Pr.type != ModContent.ProjectileType<Projectiles.Ghostflame>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.WallofSteelLaser>() && Pr.type != ModContent.ProjectileType<Projectiles.PhantasmLaser>() && Pr.type != ModContent.ProjectileType<Projectiles.PhantasmLaser>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.ElectricBolt>() && Pr.type != ModContent.ProjectileType<Projectiles.HomingRocket>() && Pr.type != ModContent.ProjectileType<Projectiles.StingerLaser>())
                {
                    Rectangle proj2 = new Rectangle((int)Pr.position.X, (int)Pr.position.Y, Pr.width, Pr.height);
                    bool reflect = false, check = false;

                    if (proj2.Intersects(projWS) && !reflect)
                        reflect = true;

                    else check = true;
                    if (reflect && !check)
                    {
                        for (int thingy = 0; thingy < 5; thingy++)
                        {
                            int dust = Dust.NewDust(Pr.position, Pr.width, Pr.height, 15, 0f, 0f, 100, new Color(), 1f);
                            Main.dust[dust].noGravity = true;
                        }
                        Pr.hostile = false;
                        Pr.friendly = true;
                        Pr.velocity.X *= -1f;
                        Pr.velocity.Y *= -1f;
                    }
                }
            }
            foreach (NPC N in Main.npc)
            {
                if (!N.friendly && N.aiStyle == 9)
                {
                    Rectangle npc = new Rectangle((int)N.position.X, (int)N.position.Y, N.width, N.height);
                    bool reflect = false, check = false;
                    int rn = Main.rand.Next(2);
                    if (rn == 0)
                    {
                        if (npc.Intersects(projWS) && !reflect) reflect = true;
                    }
                    else check = true;
                    if (reflect && !check)
                    {
                        for (int varlex = 0; varlex < 5; varlex++)
                        {
                            int dust = Dust.NewDust(N.position, N.width, N.height, 15, 0f, 0f, 100, new Color(), 1f);
                            Main.dust[dust].noGravity = true;
                        }
                        N.friendly = true;
                        N.velocity.X *= -1f;
                        N.velocity.Y *= -1f;
                    }
                }
            }
            #endregion

            #region movement
            rotTimer += 0.025f;
            if (rotTimer > 360)
                rotTimer = 1;

            int radius = 75;
            //Vector2 endpoint = new Vector2(radius, radius).RotatedBy(MathHelper.ToRadians(rotTimer));
            Vector2 endpoint = player.Center + Vector2.One.RotatedBy(rotTimer) * radius;
            projectile.Center = endpoint;
            #endregion

            #region projectile
            Vector2 cursor = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            Vector2 dirToCursor = (cursor - projectile.Center).SafeNormalize(-Vector2.UnitY);
            projectile.rotation = dirToCursor.ToRotation() + MathHelper.ToRadians(180f);

            if (projTimer-- < 0)
                projTimer = 0;

            if (player.itemAnimation != 0 && player.HeldItem.damage != 0 && projTimer == 0)
            {
                int laser = Projectile.NewProjectile(projectile.Center, dirToCursor * 36f, ModContent.ProjectileType<Projectiles.StingerLaser>(), projectile.damage, 0f, projectile.owner);
                Main.projectile[laser].hostile = false;
                Main.projectile[laser].friendly = true;
                Main.projectile[laser].tileCollide = false;
                Main.PlaySound(SoundID.Item, projectile.Center, 12);
                projTimer = 120 + Main.rand.Next(60);
            }
            #endregion
        }
    }
}