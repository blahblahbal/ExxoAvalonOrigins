﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

public class AmethystAmulet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Amethyst Amulet");
        Tooltip.SetDefault("5% increased magic damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 0, 30);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage(DamageClass.Magic) += 0.05f;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.Amethyst, 12).AddIngredient(ItemID.Chain).AddTile(TileID.Anvils).Register();
    }
}