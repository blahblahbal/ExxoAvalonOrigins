﻿using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes
{
    class FlankersTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flanker's Tome");
            Tooltip.SetDefault("Tome\n+10% melee damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.value = 15000;
            Item.height = dims.Height;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) += 0.1f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<StrongVenom>(), 3).AddIngredient(ModContent.ItemType<FineLumber>(), 50).AddIngredient(ModContent.ItemType<RubybeadHerb>()).AddIngredient(ModContent.ItemType<MysticalTomePage>()).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
        }
    }
}
