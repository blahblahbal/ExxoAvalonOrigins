using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
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
            item.consumable = true;
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 17;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina = 95;
            item.maxStack = 75;
            item.value = 2000;
            item.useAnimation = 17;
            item.height = dims.Height;
            item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<StaminaPotion>());
            recipe.AddIngredient(ItemID.SharkFin, 3);
            recipe.AddIngredient(ItemID.Mushroom, 5);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStam >= player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax2) return false;
            return true;
        }
        public override bool UseItem(Player player)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStam += 95;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().StaminaHealEffect(95, true);
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStam > player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax2)
            {
                player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStam = player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax2;
            }
            return true;
        }
    }
}
