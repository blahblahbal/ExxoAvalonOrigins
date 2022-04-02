using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class DionysusAmulet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dionysus Amulet");
        Tooltip.SetDefault("Increases your max number of minions by 2\n8% increased minion damage\nIncreases armor penetration by 5");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Pink;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 2);
        Item.height = dims.Height;
        Item.defense = 3;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.maxMinions += 2;
        player.GetDamage(DamageClass.Summon) += 0.08f;
        player.armorPenetration += 5;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<PygmyShield>()).AddIngredient(ModContent.ItemType<PeridotAmulet>()).AddIngredient(ItemID.SharkToothNecklace).AddTile(TileID.TinkerersWorkbench).Register();
    }
}