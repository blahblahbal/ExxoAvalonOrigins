using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class FocusPulse : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Focus Pulse");
			Tooltip.SetDefault("Fires a sustained-beam chaining-homing laser");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.magic = true;
			item.damage = 47;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1f;
			item.shootSpeed = 15f;
			item.crit += 1;
			item.mana = 18;
			item.rare = ItemRarityID.Orange;
            item.channel = true;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 27;
			item.knockBack = 5f;
			item.shoot = ModContent.ProjectileType<Projectiles.PulseLaser>();
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 388500;
			item.useAnimation = 27;
			item.height = dims.Height;
            //item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Beam");
		}
	}
}
