using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{
    public class StingerLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stinger Laser");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/StingerLaser");
            projectile.width = dims.Width * 4 / 20;
            projectile.height = dims.Height * 4 / 20 / Main.projFrames[projectile.type];
            projectile.aiStyle = 1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.light = 0.8f;
            projectile.alpha = 0;
            projectile.scale = 1.2f;
            projectile.timeLeft = 1200;
            projectile.ranged = true;
            aiType = ProjectileID.DeathLaser;
        }
    }}