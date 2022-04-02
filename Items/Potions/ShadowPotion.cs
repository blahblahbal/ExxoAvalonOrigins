using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions;

class ShadowPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shadow Potion");
        Tooltip.SetDefault("Enables teleportation to the cursor");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.buffType = ModContent.BuffType<Buffs.Shadows>();
        Item.consumable = true;
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.maxStack = 100;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.buffTime = 25200;
        Item.UseSound = SoundID.Item3;
    }
    public override void AddRecipes()
    {
        CreateRecipe(5).AddIngredient(ItemID.BottledWater, 5).AddIngredient(ModContent.ItemType<Material.ChaosDust>(), 9).AddIngredient(ItemID.Waterleaf, 3).AddIngredient(ItemID.Fireblossom, 3).AddTile(TileID.Bottles).Register();
    }
}