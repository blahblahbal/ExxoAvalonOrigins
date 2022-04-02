using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
class HellsteelPants : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hellsteel Greaves");
        Tooltip.SetDefault("14% increased movement speed\nIncreases your max number of minions by 1");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 27;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 9, 0, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.HellsteelPlate>(), 20).AddIngredient(ModContent.ItemType<FleshPants>()).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
    }
    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.14f;
        player.maxMinions++;
    }
}