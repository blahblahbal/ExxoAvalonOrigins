using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions;

class PiercingPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Piercing Potion");
        Tooltip.SetDefault("Increases projectile penetration");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.buffType = ModContent.BuffType<Buffs.Piercing>();
        Item.consumable = true;
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.maxStack = 100;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.buffTime = 4 * 3600;
        Item.UseSound = SoundID.Item3;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.Holybird>()).AddIngredient(ItemID.Waterleaf).AddIngredient(ItemID.BottledWater).AddTile(TileID.Bottles).Register();
    }
}