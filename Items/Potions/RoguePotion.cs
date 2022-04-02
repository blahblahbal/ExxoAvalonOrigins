using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions;

class RoguePotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Rogue Potion");
        Tooltip.SetDefault("-5% ranged damage, 20% chance to not consume ammo");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.buffType = ModContent.BuffType<Buffs.Rogue>();
        Item.consumable = true;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.maxStack = 100;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.buffTime = 16200;
        Item.UseSound = SoundID.Item3;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ModContent.ItemType<Material.Sweetstem>()).AddIngredient(ItemID.Blinkroot).AddIngredient(ItemID.SpecularFish).AddTile(TileID.Bottles).Register();
    }
}