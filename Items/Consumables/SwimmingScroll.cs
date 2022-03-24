using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
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
            r.AddIngredient(ItemID.Flipper);
            r.AddIngredient(ModContent.ItemType<StaminaCrystal>());
            r.AddTile(TileID.Bookcases);
            r.SetResult(this);
            r.AddRecipe();
        }
        public override bool CanUseItem(Player player)
        {
            return !player.Avalon().swimmingUnlocked;
        }
        public override bool UseItem(Player player)
        {
            player.Avalon().swimmingUnlocked = true;
            return true;
        }
    }
}
