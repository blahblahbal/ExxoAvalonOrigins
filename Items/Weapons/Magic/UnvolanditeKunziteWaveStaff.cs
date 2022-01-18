using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class UnvolanditeKunziteWaveStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unvolandite-Kunzite Wave Staff");
            Tooltip.SetDefault("Sprays out a wave of showers");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.magic = true;
            item.damage = 90;
            item.autoReuse = true;
            item.shootSpeed = 15f;
            item.mana = 30;
            item.noMelee = true;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.knockBack = 3f;
            item.useTime = 25;
            item.shoot = ModContent.ProjectileType<Projectiles.KunziteShower>();
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 60, 0, 0);
            item.useAnimation = 25;
            item.height = dims.Height;
            item.UseSound = SoundID.Item43;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            for (int num158 = 0; num158 < 6; num158++)
            {
                float num159 = speedX;
                float num160 = speedY;
                num159 += (float)Main.rand.Next(-40, 41) * 0.05f;
                num160 += (float)Main.rand.Next(-40, 41) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, num159, num160, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }

            return false;
        }
    }
}
