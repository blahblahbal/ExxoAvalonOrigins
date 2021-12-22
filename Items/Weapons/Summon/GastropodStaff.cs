using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Summon
{
	class GastropodStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gastropod Staff");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.summon = true;
			item.damage = 40;
			item.shootSpeed = 14f;
			item.buffType = ModContent.BuffType<Buffs.Gastropod>();
            item.buffTime = 3600;
            item.mana = 13;
			item.noMelee = true;
			item.rare = ItemRarityID.Pink;
			item.width = dims.Width;
			item.useTime = 30;
			item.knockBack = 4.5f;
			item.shoot = ModContent.ProjectileType<Projectiles.GastrominiSummon>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.useAnimation = 30;
			item.height = dims.Height;
		}

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().gastroMinion = true;
            return base.UseItem(player);
        }

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
			ref float knockBack)
		{
			float posX = (float)Main.mouseX + Main.screenPosition.X;
			float posY = (float)Main.mouseY + Main.screenPosition.Y;
			Projectile.NewProjectile(posX, posY, 0f, 0f, type, damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}
