using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class RichMahoganyBeam : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Rich Mahogany Beam");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/RichMahoganyBeam");			item.autoReuse = true;			item.consumable = true;			item.createTile = ModContent.TileType<Tiles.RichMahoganyBeam>();			item.width = dims.Width;			item.useTurn = true;			item.useTime = 10;			item.useStyle = 1;			item.maxStack = 999;			item.useAnimation = 15;			item.height = dims.Height;		}	}}