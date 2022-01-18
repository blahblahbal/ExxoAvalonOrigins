using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvForceField : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Force Field");
            Description.SetDefault("A force field surrounds you");
        }

        public override void Update(Player player, ref int k)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().forceField = true;
            var value = new Rectangle((int)player.Center.X - 32, (int)player.Center.Y - 32, 64, 64);
            var projectile = Main.projectile;
            for (var l = 0; l < projectile.Length; l++)
            {
                var Pr = projectile[l];
                if (!Pr.friendly && !Pr.bobber && Pr.type != 237 && Pr.type != ProjectileID.Stinger && Pr.type != 238 && Pr.type != 243 &&
                    Pr.type != 244 && Pr.type != 308 && Pr.type != 295 && Pr.type != 296 &&
                    Pr.type != ProjectileID.PhantasmalDeathray && Pr.type != ModContent.ProjectileType<Projectiles.Ghostflame>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.WallofSteelLaser>() && Pr.type != ModContent.ProjectileType<Projectiles.ElectricBolt>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.HomingRocket>() && Pr.type != ModContent.ProjectileType<Projectiles.StingerLaser>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.CaesiumFireball>() && Pr.type != ModContent.ProjectileType<Projectiles.CaesiumCrystal>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.CaesiumGas>() && Pr.type != ModContent.ProjectileType<Projectiles.SpikyBall>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.Spike>() && Pr.type != ModContent.ProjectileType<Projectiles.CrystalShard>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.WallofSteelLaserEnd>() && Pr.type != ModContent.ProjectileType<Projectiles.WallofSteelLaserStart>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.CrystalBit>() && Pr.type != ModContent.ProjectileType<Projectiles.CrystalBeam>())
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
