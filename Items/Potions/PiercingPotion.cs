using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class PiercingPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Piercing Potion");
			Tooltip.SetDefault("Increases projectile penetration");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.buffType = ModContent.BuffType<Buffs.Piercing>();
			item.consumable = true;
			item.rare = ItemRarityID.Green;
			item.width = dims.Width;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 100;
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 4 * 3600;
            item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Material.Holybird>());
            r.AddIngredient(ItemID.Waterleaf);
            r.AddIngredient(ItemID.BottledWater);
            r.AddTile(TileID.Bottles);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
