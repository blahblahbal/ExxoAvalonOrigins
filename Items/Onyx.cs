using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class Onyx : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Onyx");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Onyx");			item.autoReuse = true;			item.useTurn = true;			item.maxStack = 999;
            item.createTile = TileID.ExposedGems; //ModContent.TileType<PlacedGems>();			item.placeStyle = 8;			item.consumable = true;			item.rare = 8;			item.width = dims.Width;			item.useTime = 10;			item.value = 30000;			item.useStyle = 1;			item.useAnimation = 15;			item.height = dims.Height;		}	}}