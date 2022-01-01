using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class StarbrightPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starbright Potion");
			Tooltip.SetDefault("Fallen stars fall more frequently");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.buffType = ModContent.BuffType<Buffs.Starbright>();
			item.consumable = true;
			item.rare = ItemRarityID.Green;
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
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddIngredient(ItemID.Lens);
            recipe.AddIngredient(ItemID.Meteorite);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
