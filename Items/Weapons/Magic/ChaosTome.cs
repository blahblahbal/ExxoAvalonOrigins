using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class ChaosTome : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Tome");
			Tooltip.SetDefault("Casts a chaos bolt");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item20;
			item.magic = true;
			item.damage = 24;
			item.autoReuse = true;
			item.useTurn = true;
			item.shootSpeed = 8f;
			item.mana = 8;
			item.noMelee = true;
			item.rare = ItemRarityID.Green;
			item.width = dims.Width;
			item.useTime = 25;
			item.knockBack = 4f;
			item.shoot = ModContent.ProjectileType<Projectiles.ChaosBolt>();
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 18400;
			item.useAnimation = 25;
			item.height = dims.Height;
        }
	}
}
