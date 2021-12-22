using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class FlowerofTheJungle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flower of The Jungle");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.magic = true;
			item.damage = 25;
			item.shootSpeed = 5f;
			item.mana = 16;
			item.noMelee = true;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.knockBack = 5f;
			item.useTime = 16;
			item.shoot = ModContent.ProjectileType<Projectiles.JungleFire>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 0, 60, 0);
			item.useAnimation = 16;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
		}
	}
}
