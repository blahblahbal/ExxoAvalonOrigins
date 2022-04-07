using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables;

class SprintScroll : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sprint Scroll");
        Tooltip.SetDefault("Unlocks stamina sprinting");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.width = dims.Width;
        Item.useTime = 20;
        Item.rare = ItemRarityID.Green;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.UseSound = SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Item/Scroll");
        Item.useAnimation = 20;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.Book).AddIngredient(ItemID.HermesBoots).AddIngredient(ModContent.ItemType<StaminaCrystal>()).AddTile(TileID.Bookcases).Register();
        CreateRecipe(1).AddIngredient(ItemID.Book).AddIngredient(ItemID.FlurryBoots).AddIngredient(ModContent.ItemType<StaminaCrystal>()).AddTile(TileID.Bookcases).Register();
        CreateRecipe(1).AddIngredient(ItemID.Book).AddIngredient(ItemID.SailfishBoots).AddIngredient(ModContent.ItemType<StaminaCrystal>()).AddTile(TileID.Bookcases).Register();
    }
    public override bool CanUseItem(Player player)
    {
        return !player.Avalon().sprintUnlocked;
    }
    public override bool? UseItem(Player player)
    {
        player.Avalon().sprintUnlocked = true;
        return true;
    }
}
