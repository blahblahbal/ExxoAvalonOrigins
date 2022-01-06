using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class BismuthWatch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Watch");
            Tooltip.SetDefault("Tells the time");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.GoldWatch);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 10);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddTile(TileID.Chairs);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.accWatch < 1) player.accWatch = 1;
        }

        public override void UpdateInventory(Player player)
        {
            if (player.accWatch < 1) player.accWatch = 1;
        }
    }
}
