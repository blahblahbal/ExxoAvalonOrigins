using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Items{	class SouloftheJungle : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Soul of the Jungle");			Tooltip.SetDefault("'The essence of jungle monsters'");			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));			ItemID.Sets.AnimatesAsSoul[item.type] = true;			ItemID.Sets.ItemIconPulse[item.type] = true;			ItemID.Sets.ItemNoGravity[item.type] = true;		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/SouloftheJungle");			item.autoReuse = true;			item.consumable = true;			item.createTile = ModContent.TileType<Tiles.JunglesoulBlock>();			item.rare = 9;			item.width = dims.Width;			item.useTurn = true;			item.useTime = 10;			item.useStyle = 1;			item.maxStack = 999;			item.value = 70000;			item.useAnimation = 15;			item.height = dims.Height;		}	}}