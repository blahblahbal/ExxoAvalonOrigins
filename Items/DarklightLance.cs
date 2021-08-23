using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class DarklightLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darklight Lance");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/DarklightLance");
			item.UseSound = SoundID.Item1;
			item.damage = 99;
			item.noUseGraphic = true;
			item.scale = 1f;
			item.shootSpeed = 4f;
			item.rare = ItemRarityID.Yellow;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 22;
			item.useAnimation = 22;
			item.knockBack = 5.5f;
			item.shoot = ModContent.ProjectileType<Projectiles.DarklightLance>();
			item.melee = true;
			item.autoReuse = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.height = dims.Height;
		}
		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
    }
}