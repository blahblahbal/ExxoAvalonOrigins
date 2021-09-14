using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class UnderestimatedResolve : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Underestimated Resolve");
			Tooltip.SetDefault("Tome\n+20 HP, +5% ranged damage\n+4 defense");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/UnderestimatedResolve");
			item.rare = ItemRarityID.LightPurple;
			item.width = dims.Width;
			item.value = 20000;
			item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 20;
            player.rangedDamage += 0.05f;
            player.statDefense += 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Sandstone>(), 10);
            recipe.AddIngredient(ModContent.ItemType<ElementDust>(), 4);
            recipe.AddIngredient(ModContent.ItemType<MysticalClaw>(), 6);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}