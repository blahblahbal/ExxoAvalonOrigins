using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions;

class TimeShiftPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Time Shift Potion");
        Tooltip.SetDefault("Slows time down");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        //item.buffType = ModContent.BuffType<Buffs.TimeShift>();
        Item.consumable = true;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.value = 2000;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.maxStack = 100;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.buffTime = 32400;
        Item.UseSound = SoundID.Item3;
    }
    public override void AddRecipes()
    {
        CreateRecipe(5).AddIngredient(ItemID.BottledWater).AddIngredient(ItemID.BottledHoney, 5).AddIngredient(ItemID.Feather, 8).AddIngredient(ItemID.FastClock).AddTile(TileID.Bottles).Register();
    }
}