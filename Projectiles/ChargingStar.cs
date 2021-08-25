using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    class ChargingStar : ModProjectile
    {
        float CHARGE = 0;
        int STUFF = 0;
        int Pindex = -1;
        Color Color1 = Color.Yellow;
        Color Color2 = Color.Orange;
        int DT = 15;
        float dustSpeed = 1f;
        bool DrawLazer = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charging Star");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.alpha = 0;
            projectile.scale = 1;
            projectile.aiStyle = -1;
            projectile.timeLeft = 240;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.damage = 0;
            projectile.light = 1;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.tileCollide = false;
            projectile.magic = true;
        }
        public override void Kill(int timeLeft)
        {
            projectile.active = false;
        }
        public override void AI()
        {
            CHARGE++;
            Projectile P = projectile;
            P.damage = 0;
            Player O = Main.player[P.owner];
            if (CHARGE == 149)
            {
                Pindex = Projectile.NewProjectile(P.position.X + P.width / 2, P.position.Y + P.height / 2, P.velocity.X, P.velocity.Y, ModContent.ProjectileType<TheSun>(), (int)(O.inventory[O.selectedItem].damage * O.magicDamage), 3f, P.owner);
                Main.PlaySound(2, (int)P.position.X, (int)P.position.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Pulse"));
            }
            if (CHARGE == 169)
            {
                Pindex = Projectile.NewProjectile(P.position.X + P.width / 2, P.position.Y + P.height / 2, P.velocity.X, P.velocity.Y, ModContent.ProjectileType<TheSun>(), (int)(O.inventory[O.selectedItem].damage * O.magicDamage), 3f, P.owner);
                Main.PlaySound(2, (int)P.position.X, (int)P.position.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Pulse"));
            }
            if (CHARGE == 189)
            {
                Pindex = Projectile.NewProjectile(P.position.X + P.width / 2, P.position.Y + P.height / 2, P.velocity.X, P.velocity.Y, ModContent.ProjectileType<TheSun>(), (int)(O.inventory[O.selectedItem].damage * O.magicDamage), 3f, P.owner);
                Main.PlaySound(2, (int)P.position.X, (int)P.position.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Pulse"));
            }
            if (CHARGE == 209)
            {
                Pindex = Projectile.NewProjectile(P.position.X + P.width / 2, P.position.Y + P.height / 2, P.velocity.X, P.velocity.Y, ModContent.ProjectileType<TheSun>(), (int)(O.inventory[O.selectedItem].damage * O.magicDamage), 3f, P.owner);
                Main.PlaySound(2, (int)P.position.X, (int)P.position.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Pulse"));
            }
            if (CHARGE == 229)
            {
                Pindex = Projectile.NewProjectile(P.position.X + P.width / 2, P.position.Y + P.height / 2, P.velocity.X, P.velocity.Y, ModContent.ProjectileType<TheSun>(), (int)(O.inventory[O.selectedItem].damage * O.magicDamage), 3f, P.owner);
                Main.PlaySound(2, (int)P.position.X, (int)P.position.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Pulse"));
            }
            if (CHARGE == 249)
            {
                Pindex = Projectile.NewProjectile(P.position.X + P.width / 2, P.position.Y + P.height / 2, P.velocity.X, P.velocity.Y, ModContent.ProjectileType<TheSun>(), (int)(O.inventory[O.selectedItem].damage * O.magicDamage), 3f, P.owner);
                Main.PlaySound(2, (int)P.position.X, (int)P.position.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Pulse"));
            }
            if (CHARGE > 251) CHARGE = 251;
            float MY = Main.mouseY + Main.screenPosition.Y;
            float MX = Main.mouseX + Main.screenPosition.X;
            if (Main.myPlayer == P.owner)
            {
                float num119 = 0f;
                if (O.inventory[O.selectedItem].shoot == P.type)
                {
                    num119 = O.inventory[O.selectedItem].shootSpeed * P.scale;
                }
                Vector2 vector14 = new Vector2(O.position.X + (float)O.width * 0.5f, O.position.Y + (float)O.height * 0.5f);
                float num120 = MX - vector14.X;
                float num121 = MY - vector14.Y;
                float num122 = (float)Math.Sqrt((double)(num120 * num120 + num121 * num121));
                num122 = (float)Math.Sqrt((double)(num120 * num120 + num121 * num121));
                num122 = num119 / num122;
                num120 *= num122;
                num121 *= num122;
                if (num120 != P.velocity.X || num121 != P.velocity.Y)
                {
                    P.netUpdate = true;
                }
                P.velocity.X = num120;
                P.velocity.Y = num121;
                STUFF++;
                if (STUFF > 300) P.Kill();
            }
            float targetrotation = (float)Math.Atan2((MY - O.position.Y), (MX - O.position.X));
            P.rotation = targetrotation;
            O.itemTime = 2;
            O.itemAnimation = 2;
            float Dist = 60;
            P.position = new Vector2(O.itemLocation.X + (float)((float)Math.Cos(targetrotation) * Dist) * 0.66f, O.itemLocation.Y + (float)((float)Math.Sin(targetrotation) * Dist) * 0.66f);
            if (P.velocity.X < 0)
            {
                P.direction = -1;
            }
            else
            {
                P.direction = 1;
            }
            P.spriteDirection = P.direction;
            O.heldProj = P.whoAmI;
            O.direction = P.direction;
            O.itemRotation = (float)Math.Atan2((MY - O.position.Y) * O.direction, (MX - O.position.X) * O.direction) - 0.05f * O.direction;
        }
    }
}
