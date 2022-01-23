using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class SacredLyre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sacred Lyre");
            Tooltip.SetDefault("Casts bouncing notes\nNotes have a different effect depending on the distance your cursor is from you");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item8;
            item.magic = true;
            item.damage = 120;
            item.autoReuse = true;
            item.scale = 1f;
            item.shootSpeed = 4.5f;
            item.mana = 16;
            item.rare = ItemRarityID.Purple;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 10;
            item.knockBack = 1.75f;
            item.shoot = ModContent.ProjectileType<Projectiles.SacredLyreShockwaveNote>();
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.holdStyle = 3;
            item.value = 40000;
            item.useAnimation = 10;
            item.height = dims.Height;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float num70 = Main.mouseX + Main.screenPosition.X - position.X;
            float num71 = Main.mouseY + Main.screenPosition.Y - position.Y;
            if (player.gravDir == -1)
            {
                num71 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - position.Y;
            }
            float num72 = (float)Math.Sqrt(num70 * num70 + num71 * num71);
            float num73 = num72;
            num72 = item.shootSpeed / num72;
            num70 *= num72;
            num71 *= num72;
            float dist = Vector2.Distance(new Vector2(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y), player.Center);
            if (dist % (16 * 30) < 160)
            {
                type = ModContent.ProjectileType<Projectiles.SacredLyreShockwaveNote>();
            }
            else if (dist % (16 * 30) < 320)
            {
                type = ModContent.ProjectileType<Projectiles.SacredLyreSplittingNote>();
            }
            else
            {
                type = ModContent.ProjectileType<Projectiles.SacredLyreHomingNote>();
            }
            num73 /= Main.screenHeight / 2;
            if (num73 > 1f)
            {
                num73 = 1f;
            }
            float num75 = num70 + Main.rand.Next(-40, 41) * 0.01f;
            float num76 = num71 + Main.rand.Next(-40, 41) * 0.01f;
            num75 *= num73 + 0.25f;
            num76 *= num73 + 0.25f;
            int num77 = Projectile.NewProjectile(position.X, position.Y, num75, num76, type, damage, knockBack, player.whoAmI, 0f, 0f);
            Main.projectile[num77].ai[1] = 1f;
            num73 = num73 * 2f - 1f;
            if (num73 < -1f)
            {
                num73 = -1f;
            }
            if (num73 > 1f)
            {
                num73 = 1f;
            }
            Main.projectile[num77].ai[0] = num73;
            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, null, num77, 0f, 0f, 0f, 0);
            return false;
        }
    }
}
