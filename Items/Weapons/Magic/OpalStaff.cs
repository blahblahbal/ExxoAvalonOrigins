using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class OpalStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Opal Staff");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SapphireStaff);
            Item.staff[Item.type] = true;
            Rectangle dims = this.GetDims();
            Item.width = dims.Width;
            Item.height = dims.Height;
            Item.damage = 90;
            Item.autoReuse = true;
            Item.shootSpeed = 9.5f;
            Item.mana = 14;
            Item.rare = ItemRarityID.Yellow;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.knockBack = 7.5f;
            Item.shoot = ModContent.ProjectileType<Projectiles.OpalBolt>();
            Item.value = Item.buyPrice(0, 30, 0, 0);
            Item.UseSound = SoundID.Item43;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            for (int num182 = 0; num182 < 3; num182++)
            {
                float num183 = speedX;
                float num184 = speedY;
                num183 += (float)Main.rand.Next(-30, 31) * 0.05f;
                num184 += (float)Main.rand.Next(-30, 31) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, num183, num184, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }

            return false;
        }
    }
}
