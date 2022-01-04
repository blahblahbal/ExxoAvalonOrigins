using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class RhodiumHamaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rhodium Hamaxe");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 17;
			item.autoReuse = true;
			item.hammer = 60;
			item.useTurn = true;
			item.scale = 1.3f;
			item.axe = 18;
			item.crit += 5;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.useTime = 25;
			item.knockBack = 2f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 50000;
			item.useAnimation = 20;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.RhodiumBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
