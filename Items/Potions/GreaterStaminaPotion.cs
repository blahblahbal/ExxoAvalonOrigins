using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions;

class GreaterStaminaPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Greater Stamina Potion");
        Tooltip.SetDefault("Restores 95 stamina");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.rare = ItemRarityID.Pink;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 17;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina = 95;
        Item.maxStack = 75;
        Item.value = 2000;
        Item.useAnimation = 17;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item3;
    }
    public override void AddRecipes()
    {
        CreateRecipe(10).AddIngredient(ModContent.ItemType<StaminaPotion>(), 10).AddIngredient(ItemID.Feather, 2).AddIngredient(ItemID.SoulofFlight).AddTile(TileID.Bottles).Register();
    }
    public override bool CanUseItem(Player player)
    {
        if (player.Avalon().statStam >= player.Avalon().statStamMax2) return false;
        return true;
    }
    public override bool? UseItem(Player player)
    {
        player.Avalon().statStam += 95;
        player.Avalon().StaminaHealEffect(95, true);
        if (player.Avalon().statStam > player.Avalon().statStamMax2)
        {
            player.Avalon().statStam = player.Avalon().statStamMax2;
        }
        return true;
    }
}