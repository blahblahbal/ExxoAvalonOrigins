using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
class AncientLeggings : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ancient Leggings");
        Tooltip.SetDefault("Increases your max number of minions by 3\nIncreases maximum mana by 80");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 25;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 30, 0, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.SolarFlareLeggings).AddIngredient(ItemID.FragmentNebula, 10).AddIngredient(ItemID.FragmentStardust, 10).AddIngredient(ItemID.FragmentVortex, 10).AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5).AddIngredient(ModContent.ItemType<Material.GhostintheMachine>()).AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();
        CreateRecipe(1).AddIngredient(ItemID.NebulaLeggings).AddIngredient(ItemID.FragmentSolar, 10).AddIngredient(ItemID.FragmentStardust, 10).AddIngredient(ItemID.FragmentVortex, 10).AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5).AddIngredient(ModContent.ItemType<Material.GhostintheMachine>()).AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();
        CreateRecipe(1).AddIngredient(ItemID.StardustLeggings).AddIngredient(ItemID.FragmentNebula, 10).AddIngredient(ItemID.FragmentSolar, 10).AddIngredient(ItemID.FragmentVortex, 10).AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5).AddIngredient(ModContent.ItemType<Material.GhostintheMachine>()).AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();
        CreateRecipe(1).AddIngredient(ItemID.VortexLeggings).AddIngredient(ItemID.FragmentNebula, 10).AddIngredient(ItemID.FragmentStardust, 10).AddIngredient(ItemID.FragmentSolar, 10).AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5).AddIngredient(ModContent.ItemType<Material.GhostintheMachine>()).AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();
    }
    public override void UpdateEquip(Player player)
    {
        player.maxMinions += 3;
        player.statManaMax2 += 80;
    }
}
