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
	class IridiumLongbow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iridium Longbow");
		}
		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/IridiumLongbow");
			item.UseSound = SoundID.Item5;
            item.damage = 25;
			item.useTurn = true;
			item.scale = 1f;
            item.shootSpeed = 10f;
			item.useAmmo = AmmoID.Arrow;
			item.ranged = item.noMelee = true;
			item.width = dims.Width;
            item.useTime = 16;
			item.knockBack = 2f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.useStyle = ItemUseStyleID.HoldingOut;
            item.rare = ItemRarityID.LightRed;
            item.value = 25000;
			item.useAnimation = 16;
			item.height = dims.Height;
		}
	}
}