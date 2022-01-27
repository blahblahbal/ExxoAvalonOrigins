using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    public class PygmyShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pygmy Shield");
            Tooltip.SetDefault("Increases your max number of minions by 1");
        }

        public override void SetDefaults()
        {
            item.defense = 3;
            item.rare = ItemRarityID.Green;
            item.width = 20;
            item.value = Item.sellPrice(0, 0, 75);
            item.accessory = true;
            item.height = 20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltShield);
            recipe.AddIngredient(ItemID.PygmyNecklace);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions++;
            player.noKnockback = true;
        }
    }
}
