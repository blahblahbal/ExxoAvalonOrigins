using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class HungryStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hungry Staff");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.summon = true;
			item.damage = 27;
			item.shootSpeed = 14f;
			item.buffType = ModContent.BuffType<Buffs.Hungry>();
            item.buffTime = 3600;
            item.mana = 15;
			item.noMelee = true;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.useTime = 30;
			item.knockBack = 5.5f;
			item.shoot = ModContent.ProjectileType<Projectiles.HungrySummon>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.useAnimation = 30;
			item.height = dims.Height;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().hungryMinion = true;
            return base.UseItem(player);
        }

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
			ref float knockBack)
		{
			float posX = (float)Main.mouseX + Main.screenPosition.X;
			float posY = (float)Main.mouseY + Main.screenPosition.Y;
			int num227 = Projectile.NewProjectile(posX, posY, 0f, 0f, type, damage, knockBack, player.whoAmI, 0f, 0f);
			if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().fleshLaser)
			{
				Main.projectile[num227].minionSlots = 0.25f;
			}

			return false;
		}
	}
}
