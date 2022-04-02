using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions;

class LeapingPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Leaping Potion");
        Tooltip.SetDefault("Increases vertical acceleration");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.buffType = ModContent.BuffType<Buffs.Leaping>();
        Item.consumable = true;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.value = 2000;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.maxStack = 100;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.buffTime = 6 * 3600;
        Item.UseSound = SoundID.Item3;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.Holybird>()).AddIngredient(ItemID.FallenStar).AddIngredient(ItemID.Vine).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddTile(TileID.Bottles).Register();
    }
}