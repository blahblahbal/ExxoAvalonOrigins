using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Throw
{
	class MagicGrenade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Grenade");
			Tooltip.SetDefault("A small explosion that will not destroy tiles");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.magic = true;
			item.damage = 85;
			item.noUseGraphic = true;
			item.shootSpeed = 8f;
			item.mana = 40;
			item.rare = ItemRarityID.Cyan;
			item.noMelee = true;
			item.width = dims.Width;
			item.knockBack = 8f;
			item.useTime = 27;
			item.shoot = ModContent.ProjectileType<Projectiles.MagicGrenade>();
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 27;
			item.height = dims.Height;
		}
	}
}
