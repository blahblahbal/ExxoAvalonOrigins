using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class EnergyRevolver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energy Revolver");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.magic = true;
			item.damage = 57;
			item.autoReuse = true;
			item.shootSpeed = 15f;
			item.mana = 6;
			item.noMelee = true;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.knockBack = 2f;
			item.useTime = 6;
			item.shoot = ProjectileID.GreenLaser;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(0, 2, 60, 0);
			item.useAnimation = 6;
			item.height = dims.Height;
            item.UseSound = SoundID.Item12;
        }
	}
}
