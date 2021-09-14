using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace ExxoAvalonOrigins.Items
{
	class MagicCleaver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Cleaver");
		}
		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/MagicCleaver");
			item.UseSound = SoundID.Item1;
			item.magic = true;
			item.damage = 85;
			item.autoReuse = true;
			item.shootSpeed = 20;
			item.mana = 16;
			item.rare = ItemRarityID.Red;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.width = dims.Width;
			item.useTime = 18;
			item.knockBack = 5f;
			item.shoot = ModContent.ProjectileType<Projectiles.MagicCleaver>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 36000;
			item.useAnimation = 18;
			item.height = dims.Height;
        }
	}
}