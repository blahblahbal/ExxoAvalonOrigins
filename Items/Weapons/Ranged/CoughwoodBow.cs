using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
	class CoughwoodBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coughwood Bow");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item5;
			item.damage = 9;
			item.useTurn = true;
			item.scale = 1f;
			item.shootSpeed = 7f;
			item.useAmmo = AmmoID.Arrow;
			item.ranged = true;
			item.rare = ItemRarityID.White;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 0f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.useAnimation = 20;
			item.height = dims.Height;
		}
	}
}
