using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class TroxiniumBar : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Troxinium Bar");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TroxiniumBar");			item.autoReuse = true;			item.useTurn = true;			item.maxStack = 999;			item.consumable = true;			item.createTile = TileID.MetalBars;			item.placeStyle = 32;			item.rare = 5;			item.width = dims.Width;			item.useTime = 10;			item.value = Item.sellPrice(0, 0, 75, 0);			item.useStyle = 1;			item.useAnimation = 15;			item.height = dims.Height;		}	}}