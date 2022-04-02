using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables;

class SwimmingScroll : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Swimming Scroll");
        Tooltip.SetDefault("Unlocks stamina swimming");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.width = dims.Width;
        Item.useTime = 20;
        Item.rare = ItemRarityID.Green;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.UseSound = Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Scroll");
        Item.useAnimation = 20;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.Book).AddIngredient(ItemID.Flipper).AddIngredient(ModContent.ItemType<StaminaCrystal>()).AddTile(TileID.Bookcases).Register();
    }
    public override bool CanUseItem(Player player)
    {
        return !player.Avalon().swimmingUnlocked;
    }
    public override bool? UseItem(Player player)
    {
        player.Avalon().swimmingUnlocked = true;
        return true;
    }
}