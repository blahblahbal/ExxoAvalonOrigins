using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class AngelSculpture : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Angel Sculpture");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/AngelSculpture");			item.autoReuse = true;			item.consumable = true;			item.createTile = ModContent.TileType<Tiles.Statues>();			item.placeStyle = 9;			item.width = dims.Width;			item.useTurn = true;			item.useTime = 10;			item.useStyle = 1;			item.maxStack = 99;			item.value = 300;			item.useAnimation = 15;			item.height = dims.Height;		}	}}