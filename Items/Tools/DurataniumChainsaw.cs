using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class DurataniumChainsaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duratanium Chainsaw");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item23;
			item.damage = 25;
			item.noUseGraphic = true;
			item.channel = true;
			item.axe = 15;
			item.shootSpeed = 40f;
			item.rare = ItemRarityID.LightRed;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 6;
			item.knockBack = 3.5f;
			item.shoot = ModContent.ProjectileType<Projectiles.DurataniumChainsaw>();
			item.melee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 88000;
			item.useAnimation = 25;
			item.height = dims.Height;
		}
	}
}
