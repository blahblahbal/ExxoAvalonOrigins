using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class RhodiumLongbow : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Rhodium Longbow");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/RhodiumLongbow");			item.UseSound = SoundID.Item5;
            item.damage = 21;			item.useTurn = true;			item.scale = 1f;
            item.shootSpeed = 9f;			item.useAmmo = AmmoID.Arrow;			item.ranged = item.noMelee = true;			item.width = dims.Width;
            item.useTime = 18;			item.knockBack = 1.3f;			item.shoot = 1;			item.useStyle = 5;
            item.rare = 3;
            item.value = Item.sellPrice(0, 0, 50);			item.useAnimation = 18;			item.height = dims.Height;		}	}}