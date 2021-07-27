using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class Wheezebow : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Wheezebow");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Wheezebow");			item.damage = 16;			item.useTurn = true;			item.scale = 1f;			item.shootSpeed = 9f;			item.useAmmo = AmmoID.Arrow;			item.ranged = true;			item.rare = 1;			item.width = dims.Width;			item.useTime = 20;			item.knockBack = 0f;			item.shoot = 1;			item.useStyle = 5;			item.value = Item.sellPrice(0, 0, 36, 0);			item.useAnimation = 20;			item.height = dims.Height;		}	}}