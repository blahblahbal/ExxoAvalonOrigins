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
	class FlankersTome : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flanker's Tome");
			Tooltip.SetDefault("Tome\n+10% melee damage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/FlankersTome");
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.value = 15000;
			item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += 0.1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<StrongVenom>(), 3);
            recipe.AddIngredient(ModContent.ItemType<FineLumber>(), 50);
            recipe.AddIngredient(ModContent.ItemType<RubybeadHerb>());
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>());
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}