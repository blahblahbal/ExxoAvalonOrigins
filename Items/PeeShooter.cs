using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class PeeShooter : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Pee Shooter");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/PeeShooter");			item.damage = 8;			item.scale = 0.9f;			item.useAmmo = AmmoID.Bullet;			item.shootSpeed = 7f;			item.ranged = true;			item.noMelee = true;			item.rare = 1;			item.width = dims.Width;			item.useTime = 13;			item.shoot = 14;			item.useStyle = 5;			item.value = 50000;			item.useAnimation = 13;			item.height = dims.Height;		}	}}