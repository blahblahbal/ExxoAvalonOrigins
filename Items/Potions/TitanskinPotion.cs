using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class TitanskinPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titanskin Potion");
			Tooltip.SetDefault("-8% damage, +15 defense");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.buffType = ModContent.BuffType<Buffs.Titanskin>();
			item.consumable = true;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 100;
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 14400;
            item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.RhodiumOre>());
            recipe.AddIngredient(ModContent.ItemType<Material.Sweetstem>());
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.OsmiumOre>());
            recipe.AddIngredient(ModContent.ItemType<Material.Sweetstem>());
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
