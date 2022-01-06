﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Other
{
	class LargeTourmaline : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Large Tourmaline");
			Tooltip.SetDefault("For Capture the Gem. It drops when you die");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LargeAmber);
			Rectangle dims = item.modItem.GetDims();
			item.rare = ItemRarityID.Blue;
			item.width = 20;
			item.height = 20;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Tourmaline>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D itemTexture = item.modItem.GetTexture();
			float num5 = item.height - itemTexture.Height;
			float num6 = item.width / 2 - itemTexture.Width / 2;

			Main.spriteBatch.Draw(itemTexture, new Vector2(item.position.X - Main.screenPosition.X + (float)(itemTexture.Width / 2) + num6, item.position.Y - Main.screenPosition.Y + (float)(itemTexture.Height / 2) + num5 + 2f), new Rectangle(0, 0, itemTexture.Width, itemTexture.Height), new Color(250, 250, 250, (int)Main.mouseTextColor / 2), rotation, new Vector2(itemTexture.Width / 2, itemTexture.Height / 2), (float)(int)Main.mouseTextColor / 1000f + 0.8f, SpriteEffects.None, 0f);
		}
	}
}