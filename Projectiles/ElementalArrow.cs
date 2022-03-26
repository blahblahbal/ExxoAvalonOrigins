using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class ElementalArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Arrow");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/ElementalArrow");
            projectile.penetrate = 3;
            projectile.width = dims.Width * 10 / 32;
            projectile.height = dims.Height * 10 / 32 / Main.projFrames[projectile.type];
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            aiType = ProjectileID.WoodenArrowFriendly;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int randomNum = Main.rand.Next(7);
            if (randomNum == 0) target.AddBuff(BuffID.Poisoned, 300);
            else if (randomNum == 1) target.AddBuff(BuffID.OnFire, 200);
            else if (randomNum == 2) target.AddBuff(BuffID.Confused, 120);
            else if (randomNum == 3) target.AddBuff(BuffID.CursedInferno, 300);
            else if (randomNum == 4) target.AddBuff(BuffID.Frostburn, 300);
            else if (randomNum == 5) target.AddBuff(BuffID.Venom, 240);
            else if (randomNum == 6) target.AddBuff(BuffID.Ichor, 300);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            int randomNum = Main.rand.Next(7);
            if (randomNum == 0) target.AddBuff(BuffID.Poisoned, 300);
            else if (randomNum == 1) target.AddBuff(BuffID.OnFire, 200);
            else if (randomNum == 2) target.AddBuff(BuffID.Confused, 120);
            else if (randomNum == 3) target.AddBuff(BuffID.CursedInferno, 300);
            else if (randomNum == 4) target.AddBuff(BuffID.Frostburn, 300);
            else if (randomNum == 5) target.AddBuff(BuffID.Venom, 240);
            else if (randomNum == 6) target.AddBuff(BuffID.Ichor, 300);
        }
    }
}
