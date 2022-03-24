using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
    class TeleportScroll : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Teleport Scroll");
            Tooltip.SetDefault("Unlocks stamina teleport");
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
            r.AddIngredient(ModContent.ItemType<Material.ChaosDust>(), 15);
            r.AddIngredient(ItemID.SoulofSight, 5);
            r.AddIngredient(ModContent.ItemType<StaminaCrystal>());
            r.AddTile(TileID.Bookcases);
            r.SetResult(this);
            r.AddRecipe();
        }
        public override bool CanUseItem(Player player)
        {
            return !player.Avalon().teleportUnlocked;
        }
        public override bool UseItem(Player player)
        {
            player.Avalon().teleportUnlocked = true;
            return true;
        }
    }
}
