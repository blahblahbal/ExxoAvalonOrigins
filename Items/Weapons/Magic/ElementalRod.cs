using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class ElementalRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Rod");
			Tooltip.SetDefault("Will inflict debuffs");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.magic = true;
			item.damage = 45;
			item.channel = true;
			item.shootSpeed = 9f;
			item.mana = 19;
			item.crit += 16;
			item.rare = ItemRarityID.Yellow;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 23;
			item.knockBack = 4f;
			item.shoot = ModContent.ProjectileType<Projectiles.ElementOrb>();
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 23;
			item.height = dims.Height;
		}
	}
}
