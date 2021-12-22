using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class CursedFlamelash : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Flamelash");
			Tooltip.SetDefault("Summons a controllable ball of cursed fire");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item20;
			item.magic = true;
			item.damage = 40;
			item.channel = true;
			item.shootSpeed = 6f;
			item.mana = 17;
			item.rare = ItemRarityID.Pink;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 23;
			item.knockBack = 4f;
			item.shoot = ModContent.ProjectileType<Projectiles.CursedFlamelash>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 250000;
			item.useAnimation = 23;
			item.height = dims.Height;
		}
	}
}
