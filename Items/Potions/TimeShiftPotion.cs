﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class TimeShiftPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Time Shift Potion");
			Tooltip.SetDefault("Slows time down");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			//item.buffType = ModContent.BuffType<Buffs.TimeShift>();
			item.consumable = true;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.useTime = 15;
			item.value = 2000;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 100;
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 32400;
            item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.BottledHoney, 5);
            recipe.AddIngredient(ItemID.Feather, 8);
            recipe.AddIngredient(ItemID.FastClock);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}
