using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
	class Infernasword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infernasword");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 44;
			item.autoReuse = true;
			item.shootSpeed = 4f;
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.knockBack = 4f;
			item.useTime = 20;
			item.shoot = ModContent.ProjectileType<Projectiles.InfernoScythe>();
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 0, 80, 0);
			item.useAnimation = 20;
			item.height = dims.Height;
		}
	}
}
