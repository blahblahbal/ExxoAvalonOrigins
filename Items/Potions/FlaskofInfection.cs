using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class FlaskofInfection : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flask of Infection");
			Tooltip.SetDefault("Melee attacks inflict Infected on enemies");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.useTurn = true;
			item.maxStack = 100;
			item.buffType = ModContent.BuffType<Buffs.WeaponImbuePathogen>();
			item.consumable = true;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.useTime = 17;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.useAnimation = 17;
			item.height = dims.Height;
			item.buffTime = 54000;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Material.Pathogen>(), 5);
            recipe.AddTile(TileID.ImbuingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
