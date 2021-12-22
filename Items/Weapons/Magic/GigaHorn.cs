using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class GigaHorn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Giga Horn");
			Tooltip.SetDefault("Summons a powerful sonic blast");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.magic = true;
			item.damage = 45;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 0.9f;
			item.shootSpeed = 2f;
			item.mana = 60;
			item.crit += 3;
			item.noMelee = true;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.knockBack = 4f;
			item.useTime = 29;
			item.shoot = ModContent.ProjectileType<Projectiles.Soundwave>();
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/GigaHorn");
			item.value = Item.sellPrice(0, 9, 0, 0);
			item.reuseDelay = 14;
			item.useAnimation = 29;
			item.height = dims.Height;
		}
	}
}
