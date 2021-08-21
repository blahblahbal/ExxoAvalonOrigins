using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;using Microsoft.Xna.Framework.Graphics;namespace ExxoAvalonOrigins.Items{	class SoulofTorture : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Soul of Torture");			Tooltip.SetDefault("'The essence of cruelty'\nIncreases critical strike chance if placed");			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));			ItemID.Sets.AnimatesAsSoul[item.type] = true;			ItemID.Sets.ItemIconPulse[item.type] = true;			ItemID.Sets.ItemNoGravity[item.type] = true;		}
		public override Color? GetAlpha(Color lightColor)		{			return new Color(255, 255, 255, 100);		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/SoulofTorture");			item.autoReuse = true;			item.consumable = true;			item.createTile = ModContent.TileType<Tiles.TorturesoulBlock>();			item.rare = 10;			item.width = dims.Width;            item.noUseGraphic = true;
            item.useTurn = true;			item.useTime = 10;			item.useStyle = 1;			item.maxStack = 999;			item.value = 90000;			item.useAnimation = 15;			item.height = 28;		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			float num7 = (float)Main.rand.Next(90, 111) * 0.01f;
			num7 *= Main.essScale;
			Lighting.AddLight((int)((item.position.X + (float)(item.width / 2)) / 16f), (int)((item.position.Y + (float)(item.height / 2)) / 16f), 0.5f * num7, 0.01f * num7, 0.01f * num7);
		}	}}