using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{
    public class ToxinSplash : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toxin Splash");
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/ToxinSplash");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.light = 0.2f;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) { return false; }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 300);
        }    }}