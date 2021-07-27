using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class SoulEdge : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Soul Edge");			Tooltip.SetDefault("'Haunted by souls of darkness'");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/SoulEdge");			item.damage = 93;			item.autoReuse = true;			item.scale = 1.1f;			item.shootSpeed = 4f;			item.rare = 8;			item.noMelee = false;			item.width = dims.Width;			item.useTime = 20;			item.knockBack = 6.5f;			item.shoot = 297;			item.melee = true;			item.useStyle = 1;			item.value = Item.sellPrice(0, 80, 0, 0);			item.useAnimation = 20;			item.height = dims.Height;		}		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,			ref float knockBack)		{			for (int num140 = 0; num140 < 2; num140++)			{				float num141 = speedX + Main.rand.Next(-40, 41) * 0.05f;				float num142 = speedY + Main.rand.Next(-40, 41) * 0.05f;				int num143 = Projectile.NewProjectile(position.X, position.Y, num141, num142, type, damage / 3 * 2, knockBack, player.whoAmI, 0f, 0f);				Main.projectile[num143].penetrate = 2;				Main.projectile[num143].magic = false;				Main.projectile[num143].melee = true;			}			return false;		}	}}