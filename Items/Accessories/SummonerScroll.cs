using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    public class SummonerScroll : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Summoner Scroll");
            Tooltip.SetDefault("17% increased minion damage\nIncreases your max number of minions by 1");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Green;
            item.width = 20;
            item.value = Item.sellPrice(0, 2);
            item.accessory = true;
            item.height = 20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SummonerEmblem);
            recipe.AddIngredient(ItemID.PapyrusScarab);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.minionDamage += 0.17f;
            player.maxMinions++;
        }
    }
}
