using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items.Weapons
{
	class StarlightCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starlight Cannon");
            Tooltip.SetDefault("Fires large balls of star matter\nCharges for 2.5 seconds");
		}
		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Weapons/StarlightCannon");
			item.damage = 350;
			item.scale = 1.1f;
			item.magic = true;
			item.autoReuse = true;
			item.useTurn = true;
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
            item.channel = true;
			item.height = dims.Height;
            item.mana = 50;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 7f;
			item.shoot = ModContent.ProjectileType<Projectiles.ChargingStar>();
			item.shootSpeed = 6f;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Charging");
			item.value = 15500000;
		}
		
	}
}