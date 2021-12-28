using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

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
                var projectile2 = projectile[l];
                if (!projectile2.friendly && !projectile2.bobber && projectile2.type != 237 && projectile2.type != ProjectileID.Stinger && projectile2.type != 238 && projectile2.type != 243 &&
                    projectile2.type != 244 && projectile2.type != 308 && projectile2.type != 295 && projectile2.type != 296 &&
                    projectile2.type != ProjectileID.PhantasmalDeathray && projectile2.type != ModContent.ProjectileType<Projectiles.Ghostflame>() &&
                    projectile2.type != ModContent.ProjectileType<Projectiles.WallofSteelLaser>() && projectile2.type != ModContent.ProjectileType<Projectiles.ElectricBolt>() &&
                    projectile2.type != ModContent.ProjectileType<Projectiles.HomingRocket>() && projectile2.type != ModContent.ProjectileType<Projectiles.StingerLaser>() &&
                    projectile2.type != ModContent.ProjectileType<Projectiles.CaesiumFireball>() && projectile2.type != ModContent.ProjectileType<Projectiles.CaesiumCrystal>() &&
                    projectile2.type != ModContent.ProjectileType<Projectiles.CaesiumGas>())
                {
                    var rectangle = new Rectangle((int)projectile2.position.X, (int)projectile2.position.Y, projectile2.width, projectile2.height);
                    if (rectangle.Intersects(value))
                    {
                        for (var m = 0; m < 5; m++)
                        {
                            var num = Dust.NewDust(projectile2.position, projectile2.width, projectile2.height, DustID.MagicMirror, 0f, 0f, 100, default(Color), 1f);
                            Main.dust[num].noGravity = true;
                        }
                        projectile2.hostile = false;
                        projectile2.friendly = true;
                        var expr_605_cp_0 = projectile2;
                        expr_605_cp_0.velocity.X = expr_605_cp_0.velocity.X * -1f;
                        var expr_61D_cp_0 = projectile2;
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
