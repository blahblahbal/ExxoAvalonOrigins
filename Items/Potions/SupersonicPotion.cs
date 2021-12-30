using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class SupersonicPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Supersonic Potion");
			Tooltip.SetDefault("Increases movement speed to the maximum");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.buffType = ModContent.BuffType<Buffs.Supersonic>();
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.useTime = 15;
			item.value = 2000;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.maxStack = 100;
			item.useAnimation = 15;
			item.height = dims.Height;
			item.buffTime = 6 * 3600;
            item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Material.Holybird>());
            r.AddIngredient(ItemID.Cobweb, 5);
            r.AddIngredient(ItemID.Cloud);
            r.AddIngredient(ItemID.SoulofLight);
            r.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            r.AddTile(TileID.Bottles);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
