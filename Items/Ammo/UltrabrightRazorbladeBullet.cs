using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class UltrabrightRazorbladeBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ultrabright Razorblade Bullet");
            Tooltip.SetDefault("'Randomizer be like'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.shootSpeed = 10f;
			item.damage = 20;
			item.ammo = AmmoID.Bullet;
			item.ranged = true;
			item.consumable = true;
			item.width = dims.Width;
			item.knockBack = 3.5f;
            item.rare = ItemRarityID.Cyan;
            item.shoot = ModContent.ProjectileType<Projectiles.UltrabrightRazorbladeBullet>();
			item.maxStack = 2000;
			item.value = Item.sellPrice(0, 0, 2);
			item.height = dims.Height;
		}
	}
}
