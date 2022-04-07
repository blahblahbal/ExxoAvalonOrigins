using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class AncientHeadpiece : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ancient Headpiece");
        Tooltip.SetDefault("20% increased damage\n5% increased critical strike chance");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 30;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 50, 0, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.SolarFlareHelmet).AddIngredient(ItemID.FragmentNebula, 10).AddIngredient(ItemID.FragmentStardust, 10).AddIngredient(ItemID.FragmentVortex, 10).AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5).AddIngredient(ModContent.ItemType<Material.GhostintheMachine>()).AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();
        CreateRecipe(1).AddIngredient(ItemID.NebulaHelmet).AddIngredient(ItemID.FragmentSolar, 10).AddIngredient(ItemID.FragmentStardust, 10).AddIngredient(ItemID.FragmentVortex, 10).AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5).AddIngredient(ModContent.ItemType<Material.GhostintheMachine>()).AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();
        CreateRecipe(1).AddIngredient(ItemID.StardustHelmet).AddIngredient(ItemID.FragmentNebula, 10).AddIngredient(ItemID.FragmentSolar, 10).AddIngredient(ItemID.FragmentVortex, 10).AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5).AddIngredient(ModContent.ItemType<Material.GhostintheMachine>()).AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();
        CreateRecipe(1).AddIngredient(ItemID.VortexHelmet).AddIngredient(ItemID.FragmentNebula, 10).AddIngredient(ItemID.FragmentStardust, 10).AddIngredient(ItemID.FragmentSolar, 10).AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5).AddIngredient(ModContent.ItemType<Material.GhostintheMachine>()).AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();
    }
    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<AncientBodyplate>() && legs.type == ModContent.ItemType<AncientLeggings>();
    }

    public override void UpdateArmorSet(Player player)
    {
        ExxoAvalonOriginsModPlayer modPlayer = player.Avalon();
        player.setBonus = "Ancient costs 50% less mana"
                          + "\nEnemies killed with a ranged weapon violently explode"
                          + "\nHas a chance to summon a sand vortex that pulls enemies in on true melee hits"
                          + "\nRight-click and hold while holding a summon weapon to direct your minions";
        modPlayer.ancientLessCost = true;
        modPlayer.ancientGunslinger = true;
        modPlayer.ancientMinionGuide = true;
        modPlayer.ancientSandVortex = true;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Generic) += 0.2f;
        player.GetCritChance(DamageClass.Generic) += 5;
    }
}
