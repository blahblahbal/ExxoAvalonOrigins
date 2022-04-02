using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions;

class StarbrightPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Starbright Potion");
        Tooltip.SetDefault("Fallen stars fall more frequently");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.buffType = ModContent.BuffType<Buffs.Starbright>();
        Item.consumable = true;
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.value = 2000;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.maxStack = 100;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.buffTime = 18000;
        Item.UseSound = SoundID.Item3;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ItemID.FallenStar, 2).AddIngredient(ItemID.Lens).AddIngredient(ItemID.Meteorite).AddTile(TileID.Bottles).Register();
    }
}