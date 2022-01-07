using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class Mechazapinator : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechazapinator");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.magic = true;
			item.damage = 107;
			item.autoReuse = true;
			item.shootSpeed = 15f;
			item.mana = 20;
			item.noMelee = true;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.knockBack = 2f;
			item.useTime = 20;
			item.shoot = ModContent.ProjectileType<Projectiles.ElectricBolt>();
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(0, 10);
			item.useAnimation = 20;
			item.height = dims.Height;
            item.UseSound = SoundID.Item12;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10f, 0f);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int num182 = 0; num182 < 3; num182++)
            {
                float num183 = speedX;
                float num184 = speedY;
                num183 += Main.rand.Next(-30, 31) * 0.1f;
                num184 += Main.rand.Next(-30, 31) * 0.1f;
                int proj = Projectile.NewProjectile(position.X, position.Y, num183, num184, type, damage, knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].friendly = true;
            }
            return false;
        }
    }
}
