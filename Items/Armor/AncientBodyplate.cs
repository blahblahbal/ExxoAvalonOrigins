using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Body)]
class AncientBodyplate : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ancient Bodyplate");
        Tooltip.SetDefault("Enemies are more likely to target you\nMinion knockback is increased by 10%");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 35;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 40, 0, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.SolarFlareBreastplate).AddIngredient(ItemID.FragmentNebula, 10).AddIngredient(ItemID.FragmentStardust, 10).AddIngredient(ItemID.FragmentVortex, 10).AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5).AddIngredient(ModContent.ItemType<Material.GhostintheMachine>()).AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();
        CreateRecipe(1).AddIngredient(ItemID.NebulaBreastplate).AddIngredient(ItemID.FragmentSolar, 10).AddIngredient(ItemID.FragmentStardust, 10).AddIngredient(ItemID.FragmentVortex, 10).AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5).AddIngredient(ModContent.ItemType<Material.GhostintheMachine>()).AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();
        CreateRecipe(1).AddIngredient(ItemID.StardustBreastplate).AddIngredient(ItemID.FragmentNebula, 10).AddIngredient(ItemID.FragmentSolar, 10).AddIngredient(ItemID.FragmentVortex, 10).AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5).AddIngredient(ModContent.ItemType<Material.GhostintheMachine>()).AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();
        CreateRecipe(1).AddIngredient(ItemID.VortexBreastplate).AddIngredient(ItemID.FragmentNebula, 10).AddIngredient(ItemID.FragmentStardust, 10).AddIngredient(ItemID.FragmentSolar, 10).AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5).AddIngredient(ModContent.ItemType<Material.GhostintheMachine>()).AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();
    }
    public override void UpdateEquip(Player player)
    {
        player.aggro += 500;
        player.minionKB += 0.1f;
    }
}
