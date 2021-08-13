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

                        projectile.active = false;
                        projectile.Kill();
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

                        projectile.active = false;
                        projectile.Kill();
                    }
                }
            }
            #endregion

            #region movement
            projectile.Center = player.GetModPlayer<ExxoAvalonOriginsModPlayer>().endpoint[(int)projectile.ai[0]];
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

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.NPCKilled, projectile.position, 14);

            for (int i = 0; i < 2; i++)
            {
                int randomSize = Main.rand.Next(1, 4) / 2;
                int num161 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
                Gore gore30 = Main.gore[num161];
                Gore gore40 = gore30;
                gore40.velocity *= 0.3f;
                gore40.scale *= randomSize;
                Main.gore[num161].velocity.X += Main.rand.Next(-1, 2);
                Main.gore[num161].velocity.Y += Main.rand.Next(-1, 2);
            }
        }
    }
}