using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions;

class StaminaPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Stamina Potion");
        Tooltip.SetDefault("Restores 55 stamina");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 17;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina = 55;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.maxStack = 50;
        Item.value = 900;
        Item.useAnimation = 17;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item3;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<LesserStaminaPotion>()).AddIngredient(ItemID.GlowingMushroom).AddTile(TileID.Bottles).Register();
    }
    public override bool CanUseItem(Player player)
    {
        if (player.Avalon().statStam >= player.Avalon().statStamMax2) return false;
        return true;
    }
    public override bool? UseItem(Player player)
    {
        player.Avalon().statStam += 55;
        player.Avalon().StaminaHealEffect(55, true);
        if (player.Avalon().statStam > player.Avalon().statStamMax2)
        {
            player.Avalon().statStam = player.Avalon().statStamMax2;
        }
        return true;
    }
}