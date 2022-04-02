using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions;

class CrimsonPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Aura Potion");
        Tooltip.SetDefault("On-screen enemies take damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.buffType = ModContent.BuffType<Buffs.CrimsonDrain>();
        Item.consumable = true;
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.maxStack = 100;
        Item.value = Item.sellPrice(0, 0, 3, 0);
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.buffTime = 18000;
        Item.UseSound = SoundID.Item3;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ItemID.Deathweed).AddIngredient(ItemID.Spike).AddTile(TileID.Bottles).Register();
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ModContent.ItemType<Material.Barfbush>()).AddIngredient(ItemID.Spike).AddTile(TileID.Bottles).Register();
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ModContent.ItemType<Material.Bloodberry>()).AddIngredient(ItemID.Spike).AddTile(TileID.Bottles).Register();
    }
}