using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
class CorruptedThornGreaves : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Corrupted Thorn Greaves");
        Tooltip.SetDefault("20% increased movement speed" +
                           "\nMana regen greatly increased" +
                           "\nAttackers also take full damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Items/Armor/CorruptedThornGreaves");
        Item.defense = 15;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 1, 80, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.Spike, 20)
            .AddIngredient(ModContent.ItemType<Material.CorruptShard>(), 20)
            .AddIngredient(ModContent.ItemType<Placeable.Bar.CaesiumBar>(), 20)
            .AddIngredient(ItemID.SoulofNight, 15).AddTile(TileID.MythrilAnvil).Register();
    }
    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.20f;
        player.manaRegen += 3;
        player.turtleThorns = true;
    }
}
