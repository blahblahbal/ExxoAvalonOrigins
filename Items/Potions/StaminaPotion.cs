using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
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
            item.consumable = true;
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 17;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina = 55;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.maxStack = 50;
            item.value = 900;
            item.useAnimation = 17;
            item.height = dims.Height;
            item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LesserStaminaPotion>(), 2);
            recipe.AddIngredient(ItemID.Mushroom);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool CanUseItem(Player player)
        {
            if (player.Avalon().statStam >= player.Avalon().statStamMax2) return false;
            return true;
        }
        public override bool UseItem(Player player)
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
}
