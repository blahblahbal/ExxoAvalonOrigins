﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class BronzeHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Helmet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 2;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 0, 3, 50);
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BronzeBar>(), 12).AddTile(TileID.Anvils).Register();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BronzeChainmail>() && legs.type == ModContent.ItemType<BronzeGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+1 defense";
            player.statDefense++;
        }
    }
}
