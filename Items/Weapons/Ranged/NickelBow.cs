using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
	class NickelBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nickel Bow");
		}
		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item5;
            item.damage = 10;
			item.useTurn = true;
			item.scale = 1f;
			item.shootSpeed = 6.5f;
			item.useAmmo = AmmoID.Arrow;
			item.ranged = item.noMelee = true;
			item.width = dims.Width;
            item.useTime = 27;
			item.knockBack = 0f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 1700;
			item.useAnimation = 27;
			item.height = dims.Height;
		}
	}
}
