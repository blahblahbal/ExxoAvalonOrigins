using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class StaffoftheTempestFrigid : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Staff of the Tempest Frigid");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.summon = true;
			item.damage = 152;
			item.shootSpeed = 14f;
			item.buffType = ModContent.BuffType<Buffs.IceGolem>();
			item.mana = 30;
			item.noMelee = true;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.useTime = 30;
			item.knockBack = 8.5f;
			item.shoot = ModContent.ProjectileType<Projectiles.IceGolemSummon>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 30, 0, 0);
			item.useAnimation = 30;
			item.height = dims.Height;
		}
	}
}
