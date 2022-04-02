using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

class TheVoidlands : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("The Voidlands");
        Tooltip.SetDefault("Tome\n+15% damage, +3% critical strike chance\n+60 HP, +40 mana");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.LightPurple;
        Item.width = dims.Width;
        Item.value = 105000;
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage(DamageClass.Magic) += 0.15f;
        player.GetDamage(DamageClass.Summon) += 0.15f;
        player.GetDamage(DamageClass.Melee) += 0.15f;
        player.GetDamage(DamageClass.Ranged) += 0.15f;
        player.GetDamage(DamageClass.Throwing) += 0.15f;
        player.GetCritChance(DamageClass.Melee) += 3;
        player.GetCritChance(DamageClass.Magic) += 3;
        player.GetCritChance(DamageClass.Ranged) += 3;
        player.GetCritChance(DamageClass.Throwing) += 3;
        player.statLifeMax2 += 60;
        player.statManaMax2 += 40;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<EternitysMoon>()).AddIngredient(ModContent.ItemType<TomeofDistance>()).AddIngredient(ModContent.ItemType<FlankersTome>()).AddIngredient(ModContent.ItemType<SoutheasternPeacock>()).AddIngredient(ModContent.ItemType<BurningDesire>()).AddIngredient(ModContent.ItemType<MeditationsFlame>()).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 3).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
        CreateRecipe(1).AddIngredient(ModContent.ItemType<BurningDesire>()).AddIngredient(ModContent.ItemType<EternitysMoon>()).AddIngredient(ModContent.ItemType<SoutheasternPeacock>()).AddIngredient(ModContent.ItemType<TaleoftheDolt>()).AddIngredient(ModContent.ItemType<MeditationsFlame>()).AddIngredient(ModContent.ItemType<TaleoftheRedLotus>()).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 3).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
        CreateRecipe(1).AddIngredient(ModContent.ItemType<BurningDesire>()).AddIngredient(ModContent.ItemType<SoutheasternPeacock>()).AddIngredient(ModContent.ItemType<FlankersTome>()).AddIngredient(ModContent.ItemType<TomeofDistance>()).AddIngredient(ModContent.ItemType<TomeoftheRiverSpirits>()).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 3).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
        CreateRecipe(1).AddIngredient(ModContent.ItemType<BurningDesire>()).AddIngredient(ModContent.ItemType<TomeoftheRiverSpirits>()).AddIngredient(ModContent.ItemType<SoutheasternPeacock>()).AddIngredient(ModContent.ItemType<TaleoftheDolt>()).AddIngredient(ModContent.ItemType<TaleoftheRedLotus>()).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 3).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}