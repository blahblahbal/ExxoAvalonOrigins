﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class RhodiumPickaxe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Rhodium Pickaxe");
        Tooltip.SetDefault("Can mine Hellstone");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 11;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.crit += 5;
        Item.pick = 80;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.useTime = 13;
        Item.knockBack = 2f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 50000;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.RhodiumBar>(), 13).AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 2).AddTile(TileID.Anvils).Register();
    }
    public override void HoldItem(Player player)
    {
        if (player.inventory[player.selectedItem].type == Mod.Find<ModItem>("RhodiumPickaxe").Type)
        {
            player.pickSpeed -= 0.5f;
        }
    }
}