﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class RhodiumHamaxe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Rhodium Hamaxe");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 17;
        Item.autoReuse = true;
        Item.hammer = 60;
        Item.useTurn = true;
        Item.scale = 1.3f;
        Item.axe = 18;
        Item.crit += 5;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.useTime = 25;
        Item.knockBack = 2f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 50000;
        Item.useAnimation = 20;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.RhodiumBar>(), 10).AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 2).AddTile(TileID.Anvils).Register();
    }
}