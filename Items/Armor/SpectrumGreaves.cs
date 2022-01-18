﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class SpectrumGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectrum Greaves");
            Tooltip.SetDefault("20% chance to not consume ammo\n10% increased movement speed");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 25;
            item.rare = ItemRarityID.Red;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 40, 0, 0);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Material.DarkMatterGel>(), 40);
            recipe.AddIngredient(ModContent.ItemType<AncientLeggings>());
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Opal>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
            player.ammoCost80 = true;
        }
    }
}
