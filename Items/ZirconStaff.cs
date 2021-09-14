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
	class ZirconStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zircon Staff");
            Item.staff[item.type] = true;
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SapphireStaff);
			Item.staff[item.type] = true;
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/ZirconStaff");
            item.width = dims.Width;
            item.height = dims.Height;
            item.damage = 32;
            item.autoReuse = true;
            item.shootSpeed = 7.75f;
            item.mana = 9;
            item.rare = ItemRarityID.Green;
            item.useTime = 23;
            item.useAnimation = 23;
            item.knockBack = 4.75f;
            item.shoot = ModContent.ProjectileType<Projectiles.ZirconBolt>();
            item.value = Item.buyPrice(0, 3, 60, 0);
            item.UseSound = SoundID.Item43;
        }
	}
}