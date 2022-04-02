﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class NickelHelmet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Nickel Helmet");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 3;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 0, 8);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.NickelBar>(), 15).AddTile(TileID.Anvils).Register();
    }
    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<NickelChainmail>() && legs.type == ModContent.ItemType<NickelGreaves>();
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "+2 defense";
        player.statDefense += 2;
    }
}