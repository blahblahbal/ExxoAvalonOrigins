using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

public class LoveUpandDown : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Love Up and Down");
        Tooltip.SetDefault("Tome\n+15% damage, +7% critical strike chance, -25% mana cost\n20% chance to not consume ammo, 12 defense, +80 HP, +80 mana");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.value = 150000;
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage(DamageClass.Ranged) += 0.15f;
        player.GetDamage(DamageClass.Melee) += 0.15f;
        player.GetDamage(DamageClass.Magic) += 0.15f;
        player.GetDamage(DamageClass.Summon) += 0.15f;
        player.GetDamage(DamageClass.Throwing) += 0.15f;
        player.GetCritChance(DamageClass.Melee) += 7;
        player.GetCritChance(DamageClass.Magic) += 7;
        player.GetCritChance(DamageClass.Ranged) += 7;
        player.GetCritChance(DamageClass.Throwing) += 7;
        player.manaCost -= 0.25f;
        player.statDefense += 12;
        player.statLifeMax2 += 80;
        player.statManaMax2 += 80;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<DragonOrb>()).AddIngredient(ModContent.ItemType<AdventuresandMishaps>()).AddIngredient(ModContent.ItemType<ScrollofTome>(), 3).AddIngredient(ModContent.ItemType<FineLumber>(), 10).AddIngredient(ModContent.ItemType<Gravel>(), 15).AddIngredient(ModContent.ItemType<Sandstone>(), 20).AddIngredient(ModContent.ItemType<CarbonSteel>(), 20).AddIngredient(ModContent.ItemType<MysteriousPage>(), 5).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}