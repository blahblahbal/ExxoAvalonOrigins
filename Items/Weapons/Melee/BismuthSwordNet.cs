using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
	class BismuthSwordNet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bismuth Sword Net");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 16;
			item.autoReuse = true;
			item.width = dims.Width;
			item.useTurn = true;
			item.knockBack = 5f;
			item.useTime = 23;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.useAnimation = 23;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBroadsword>());
            recipe.AddIngredient(ItemID.BugNet);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
