using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class TheVoidlands : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Voidlands");
			Tooltip.SetDefault("Tome\n+15% damage, +3% critical strike chance\n+60 HP, +40 mana");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.LightPurple;
			item.width = dims.Width;
			item.value = 105000;
			item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.15f;
            player.minionDamage += 0.15f;
            player.meleeDamage += 0.15f;
            player.rangedDamage += 0.15f;
            player.thrownDamage += 0.15f;
            player.meleeCrit += 3;
            player.magicCrit += 3;
            player.rangedCrit += 3;
            player.thrownCrit += 3;
            player.statLifeMax2 += 60;
            player.statManaMax2 += 40;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EternitysMoon>());
            recipe.AddIngredient(ModContent.ItemType<TomeofDistance>());
            recipe.AddIngredient(ModContent.ItemType<FlankersTome>());
            recipe.AddIngredient(ModContent.ItemType<SoutheasternPeacock>());
            recipe.AddIngredient(ModContent.ItemType<BurningDesire>());
            recipe.AddIngredient(ModContent.ItemType<MeditationsFlame>());
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BurningDesire>());
            recipe.AddIngredient(ModContent.ItemType<EternitysMoon>());
            recipe.AddIngredient(ModContent.ItemType<SoutheasternPeacock>());
            recipe.AddIngredient(ModContent.ItemType<TaleoftheDolt>());
            recipe.AddIngredient(ModContent.ItemType<MeditationsFlame>());
            recipe.AddIngredient(ModContent.ItemType<TaleoftheRedLotus>());
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BurningDesire>());
            recipe.AddIngredient(ModContent.ItemType<SoutheasternPeacock>());
            recipe.AddIngredient(ModContent.ItemType<FlankersTome>());
            recipe.AddIngredient(ModContent.ItemType<TomeofDistance>());
            recipe.AddIngredient(ModContent.ItemType<TomeoftheRiverSpirits>());
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BurningDesire>());
            recipe.AddIngredient(ModContent.ItemType<TomeoftheRiverSpirits>());
            recipe.AddIngredient(ModContent.ItemType<SoutheasternPeacock>());
            recipe.AddIngredient(ModContent.ItemType<TaleoftheDolt>());
            recipe.AddIngredient(ModContent.ItemType<TaleoftheRedLotus>());
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
