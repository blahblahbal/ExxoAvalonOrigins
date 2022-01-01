﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class StrengthPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Strength Potion");
			Tooltip.SetDefault("Increases all stats");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.buffType = ModContent.BuffType<Buffs.Strong>();
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
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
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ItemID.TitaniumBar);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
