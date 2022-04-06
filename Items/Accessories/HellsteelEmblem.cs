using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class HellsteelEmblem : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hellsteel Emblem");
        Tooltip.SetDefault("12% increased critical strike damage\n15% increased damage\nProvides immunity to traps");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Red;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 9);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage(DamageClass.Generic) += 0.15f;
        player.Avalon().critDamageMult += 0.12f;
        player.Avalon().trapImmune = true;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<ChaosEmblem>()).AddIngredient(ModContent.ItemType<GuardianBoots>()).AddIngredient(ModContent.ItemType<Material.HellsteelPlate>(), 20).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
    }
}
