using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class PyroscoricPickaxe : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Magmatic Pickaxe");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/PyroscoricPickaxe");			item.damage = 30;			item.autoReuse = true;			item.useTurn = true;			item.scale = 1.15f;			item.pick = 250;			item.rare = 8;			item.width = dims.Width;			item.useTime = 9;			item.knockBack = 3.5f;			item.melee = true;			item.tileBoost += 2;			item.useStyle = 1;			item.value = 416000;			item.useAnimation = 11;			item.height = dims.Height;		}	}}