using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class DragonOrb : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Dragon Orb");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/DragonOrb");			item.rare = 2;			item.width = dims.Width;			item.value = Item.sellPrice(0, 0, 2, 0);			item.maxStack = 999;			item.height = dims.Height;		}	}}