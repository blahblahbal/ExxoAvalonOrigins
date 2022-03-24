using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
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
            item.consumable = true;
            item.width = dims.Width;
            item.useTime = 20;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Scroll");
            item.useAnimation = 20;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Book);
            r.AddIngredient(ItemID.HermesBoots);
            r.AddIngredient(ModContent.ItemType<StaminaCrystal>());
            r.AddTile(TileID.Bookcases);
            r.SetResult(this);
        }
        public override bool UseItem(Player player)
        {
            player.Avalon().sprintUnlocked = true;
            return true;
        }
    }
}
