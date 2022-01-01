using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class GPSPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("GPS Potion");
			Tooltip.SetDefault("GPS Effect");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.buffType = ModContent.BuffType<Buffs.GPS>();
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTime = 15;
			item.value = 2000;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 100;
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 18000;
            item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Beak>());
            recipe.AddIngredient(ItemID.IronOre);
            recipe.AddIngredient(ModContent.ItemType<Material.RottenEye>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Beak>());
            recipe.AddIngredient(ItemID.LeadOre);
            recipe.AddIngredient(ModContent.ItemType<Material.RottenEye>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Beak>());
            recipe.AddIngredient(ItemID.IronOre);
            recipe.AddIngredient(ModContent.ItemType<Material.Patella>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Beak>());
            recipe.AddIngredient(ItemID.LeadOre);
            recipe.AddIngredient(ModContent.ItemType<Material.Patella>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
