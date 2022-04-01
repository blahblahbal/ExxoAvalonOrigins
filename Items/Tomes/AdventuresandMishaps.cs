﻿using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes
{
    public class AdventuresandMishaps : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventures and Mishaps");
            Tooltip.SetDefault("Tome\n+60 HP, +5% damage\n-10% mana cost");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Lime;
            Item.width = dims.Width;
            Item.value = 20000;
            Item.height = dims.Height;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 60;
            player.GetDamage(DamageClass.Magic) += 0.05f;
            player.GetDamage(DamageClass.Summon) += 0.05f;
            player.GetDamage(DamageClass.Melee) += 0.05f;
            player.GetDamage(DamageClass.Ranged) += 0.05f;
            player.GetDamage(DamageClass.Throwing) += 0.05f;
            player.manaCost -= 0.1f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.LifeCrystal, 2).AddIngredient(ModContent.ItemType<FineLumber>(), 10).AddIngredient(ModContent.ItemType<CarbonSteel>(), 5).AddIngredient(ModContent.ItemType<RubybeadHerb>(), 10).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 2).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
        }
    }
}
