using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
	class Snotsabre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snotsabre");
		}
		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item1;
			item.damage = 17;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.1f;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 3f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 0, 36, 0);
			item.useAnimation = 20;
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
