using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class VorazylcumKunziteBoltStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vorazylcum-Kunzite Bolt Staff");
            Tooltip.SetDefault("Fires a spread of magical bolts");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.SapphireStaff);
            Item.staff[item.type] = true;
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.height = dims.Height;
            item.damage = 92;
            item.autoReuse = true;
            item.shootSpeed = 6f;
            item.mana = 37;
            item.rare = ItemRarityID.Cyan;
            item.knockBack = 3f;
            item.useTime = 40;
            item.useAnimation = 40;
            item.shoot = ModContent.ProjectileType<Projectiles.KunziteBolt>();
            item.value = Item.sellPrice(0, 60, 0, 0);
            item.UseSound = SoundID.Item43;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            for (int num161 = 0; num161 < 10; num161++)
            {
                float num162 = speedX;
                float num163 = speedY;
                num162 += (float)Main.rand.Next(-30, 31) * 0.05f;
                num163 += (float)Main.rand.Next(-30, 31) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, num162, num163, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }

            return false;
        }
    }
}
