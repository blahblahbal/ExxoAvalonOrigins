using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
	class LesserStaminaPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lesser Stamina Potion");
            Tooltip.SetDefault("Restores 35 stamina");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.consumable = true;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 17;
			item.useStyle = ItemUseStyleID.EatingUsing;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina = 35;
            item.maxStack = 30;
			item.value = 400;
			item.useAnimation = 17;
			item.height = dims.Height;
            item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Boltstone>(), 5);
            recipe.AddIngredient(ItemID.Silk);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStam >= player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax2) return false;
            return true;
        }
        public override bool UseItem(Player player)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStam += 35;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().StaminaHealEffect(35, true);
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStam > player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax2)
            {
                player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStam = player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax2;
            }
            return true;
        }
    }
}
