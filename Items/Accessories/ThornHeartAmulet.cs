using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class ThornHeartAmulet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Thorned Heart Amulet");
        Tooltip.SetDefault("Damage increases as your health drops");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 2);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.Chain).AddIngredient(ItemID.LifeCrystal).AddIngredient(ItemID.Stinger, 6).AddIngredient(ItemID.SoulofNight, 8).AddTile(TileID.TinkerersWorkbench).Register();
    }
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        float dmg = (2 * (float)Math.Floor((player.statLifeMax2 - (double)player.statLife) / player.statLifeMax2 * 10)) / 50;
        if (dmg < 0) dmg = 0;
        //Main.NewText(player.statLifeMax2);
        player.allDamage += dmg;
    }
}