using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class Boomlash : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boomlash");
			Tooltip.SetDefault("Summons a terrain-destroying missile");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item20;
			item.magic = true;
			item.damage = 80;
			item.channel = true;
			item.shootSpeed = 4f;
			item.mana = 40;
			item.rare = ItemRarityID.Yellow;
			item.noMelee = true;
			item.width = dims.Width;
			item.knockBack = 12f;
			item.useTime = 30;
			item.shoot = ModContent.ProjectileType<Projectiles.Boomlash>();
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 30;
			item.height = dims.Height;
		}
	}
}
