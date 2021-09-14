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
	class PeridotStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Peridot Staff");
            Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SapphireStaff);
			Item.staff[item.type] = true;
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/PeridotStaff");
			item.width = dims.Width;
			item.height = dims.Height;
			item.damage = 30;
			item.autoReuse = true;
			item.shootSpeed = 7.75f;
			item.mana = 10;
			item.rare = ItemRarityID.Blue;
			item.useTime = 26;
			item.useAnimation = 26;
			item.knockBack = 4.75f;
			item.shoot = ModContent.ProjectileType<Projectiles.PeridotBolt>();
			item.value = Item.buyPrice(0, 3, 60, 0);
			
            item.UseSound = SoundID.Item43;
        }
	}
}