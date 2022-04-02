using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions;

class WisdomPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Wisdom Potion");
        Tooltip.SetDefault("-8% magic damage, +60 mana");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.buffType = ModContent.BuffType<Buffs.Wisdom>();
        Item.consumable = true;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.maxStack = 100;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.buffTime = 14400;
        Item.UseSound = SoundID.Item3;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ModContent.ItemType<Material.Sweetstem>()).AddIngredient(ItemID.Waterleaf).AddIngredient(ItemID.Moonglow).AddIngredient(ItemID.FallenStar, 2).AddTile(TileID.Bottles).Register();
    }
}