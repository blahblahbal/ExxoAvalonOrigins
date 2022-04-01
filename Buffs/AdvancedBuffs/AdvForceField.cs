using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvForceField : ModBuff
    {
        public int[] notReflect = new int[]
        {
            ProjectileID.Stinger,
            ProjectileID.RainCloudMoving,
            ProjectileID.RainCloudRaining,
            ProjectileID.BloodCloudMoving,
            ProjectileID.BloodCloudRaining,
            ProjectileID.FrostHydra,
            ProjectileID.InfernoFriendlyBolt,
            ProjectileID.InfernoFriendlyBlast,
            ProjectileID.PhantasmalDeathray,
            ProjectileID.FlyingPiggyBank,
            ProjectileID.Glowstick,
            ProjectileID.BouncyGlowstick,
            ProjectileID.SpelunkerGlowstick,
            ProjectileID.StickyGlowstick,
            ProjectileID.WaterGun,
            ProjectileID.SlimeGun,
            ModContent.ProjectileType<Projectiles.Ghostflame>(),
            ModContent.ProjectileType<Projectiles.WallofSteelLaser>(),
            ModContent.ProjectileType<Projectiles.ElectricBolt>(),
            ModContent.ProjectileType<Projectiles.HomingRocket>(),
            ModContent.ProjectileType<Projectiles.StingerLaser>(),
            ModContent.ProjectileType<Projectiles.CaesiumFireball>(),
            ModContent.ProjectileType<Projectiles.CaesiumCrystal>(),
            ModContent.ProjectileType<Projectiles.CaesiumGas>(),
            ModContent.ProjectileType<Projectiles.SpikyBall>(),
            ModContent.ProjectileType<Projectiles.Spike>(),
            ModContent.ProjectileType<Projectiles.CrystalShard>(),
            ModContent.ProjectileType<Projectiles.WallofSteelLaserEnd>(),
            ModContent.ProjectileType<Projectiles.WallofSteelLaserStart>(),
            ModContent.ProjectileType<Projectiles.CrystalBit>(),
            ModContent.ProjectileType<Projectiles.CrystalBeam>()
        };
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Advanced Force Field");
            Description.SetDefault("A force field surrounds you");
        }

        public override void Update(Player player, ref int k)
        {
            player.Avalon().forceField = true;
            var value = new Rectangle((int)player.Center.X - 32, (int)player.Center.Y - 32, 64, 64);
            var projectile = Main.projectile;
            for (var l = 0; l < projectile.Length; l++)
            {
                var Pr = projectile[l];
                if (!Pr.friendly && !Pr.bobber && !notReflect.Contains(Pr.type))
                {
                    var rectangle = new Rectangle((int)Pr.position.X, (int)Pr.position.Y, Pr.width, Pr.height);
                    if (rectangle.Intersects(value))
                    {
                        for (var m = 0; m < 5; m++)
                        {
                            var num = Dust.NewDust(Pr.position, Pr.width, Pr.height, DustID.MagicMirror, 0f, 0f, 100, default(Color), 1f);
                            Main.dust[num].noGravity = true;
                        }
                        Pr.hostile = false;
                        Pr.friendly = true;
                        var expr_605_cp_0 = Pr;
                        expr_605_cp_0.velocity.X = expr_605_cp_0.velocity.X * -1f;
                        var expr_61D_cp_0 = Pr;
                        expr_61D_cp_0.velocity.Y = expr_61D_cp_0.velocity.Y * -1f;
                    }
                }
            }
            var npc = Main.npc;
            for (var l = 0; l < npc.Length; l++)
            {
                var nPC = npc[l];
                if (!nPC.friendly && nPC.aiStyle == 9)
                {
                    var rectangle2 = new Rectangle((int)nPC.position.X, (int)nPC.position.Y, nPC.width, nPC.height);
                    if (rectangle2.Intersects(value))
                    {
                        for (var n = 0; n < 5; n++)
                        {
                            var num2 = Dust.NewDust(nPC.position, nPC.width, nPC.height, DustID.MagicMirror, 0f, 0f, 100, default(Color), 1f);
                            Main.dust[num2].noGravity = true;
                        }
                        nPC.friendly = true;
                        var expr_721_cp_0 = nPC;
                        expr_721_cp_0.velocity.X = expr_721_cp_0.velocity.X * -1f;
                        var expr_739_cp_0 = nPC;
                        expr_739_cp_0.velocity.Y = expr_739_cp_0.velocity.Y * -1f;
                    }
                }
            }
        }
    }
}
