using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class TroxiniumSword : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Troxinium Sword");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TroxiniumSword");			item.damage = 46;			item.useTurn = true;			item.scale = 1.4f;			item.rare = 5;			item.width = dims.Width;			item.useTime = 24;			item.knockBack = 4f;			item.melee = true;			item.useStyle = 1;			item.value = Item.sellPrice(0, 1, 40, 0);			item.useAnimation = 24;			item.height = dims.Height;		}	}}