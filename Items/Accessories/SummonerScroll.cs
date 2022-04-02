using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

public class SummonerScroll : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Summoner Scroll");
        Tooltip.SetDefault("17% increased minion damage\nIncreases your max number of minions by 1");
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Green;
        Item.width = 20;
        Item.value = Item.sellPrice(0, 2);
        Item.accessory = true;
        Item.height = 20;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.SummonerEmblem).AddIngredient(ItemID.PapyrusScarab).AddTile(TileID.TinkerersWorkbench).Register();
    }
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage(DamageClass.Summon) += 0.17f;
        player.maxMinions++;
    }
}