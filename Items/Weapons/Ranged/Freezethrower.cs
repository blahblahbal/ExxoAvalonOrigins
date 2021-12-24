using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
	class Freezethrower : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Freezethrower");
			Tooltip.SetDefault("Uses gel for ammo");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item34;
			item.damage = 70;
			item.autoReuse = true;
			item.useAmmo = AmmoID.Gel;
			item.shootSpeed = 8.5f;
			item.ranged = true;
			item.noMelee = true;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.useTime = 5;
			item.knockBack = 0.625f;
			item.shoot = ModContent.ProjectileType<Projectiles.Freezethrower>();
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 1000000;
			item.useAnimation = 30;
			item.height = dims.Height;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
        public override bool ConsumeAmmo(Player player)
        {
            return player.itemAnimation >= item.useAnimation - 4;
        }
    }
}
