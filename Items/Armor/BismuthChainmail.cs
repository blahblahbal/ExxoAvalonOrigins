﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class BismuthChainmail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Chainmail");
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 30).AddTile(TileID.Anvils).Register();
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 5;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 0, 60);
            Item.height = dims.Height;
        }
    }
}
