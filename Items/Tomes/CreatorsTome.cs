﻿using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

class CreatorsTome : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Creator's Tome");
        Tooltip.SetDefault("Tome\n+20% damage, +5% critical strike chance, -20% mana cost\n25% chance to not consume ammo, 10 defense, +100 HP, +100 mana");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.value = 150000;
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage(DamageClass.Magic) += 0.2f;
        player.GetDamage(DamageClass.Summon) += 0.2f;
        player.GetDamage(DamageClass.Melee) += 0.2f;
        player.GetDamage(DamageClass.Ranged) += 0.2f;
        player.GetDamage(DamageClass.Throwing) += 0.2f;
        player.GetCritChance(DamageClass.Melee) += 5;
        player.GetCritChance(DamageClass.Magic) += 5;
        player.GetCritChance(DamageClass.Ranged) += 5;
        player.GetCritChance(DamageClass.Throwing) += 5;
        player.manaCost -= 0.2f;
        player.statDefense += 10;
        player.statLifeMax2 += 100;
        player.statManaMax2 += 100;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<DragonOrb>()).AddIngredient(ModContent.ItemType<TheVoidlands>()).AddIngredient(ModContent.ItemType<ScrollofTome>(), 2).AddIngredient(ModContent.ItemType<FineLumber>(), 5).AddIngredient(ModContent.ItemType<Gravel>(), 10).AddIngredient(ModContent.ItemType<Sandstone>(), 20).AddIngredient(ModContent.ItemType<CarbonSteel>(), 15).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}