using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
    class SuperStaminaPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Stamina Potion");
            Tooltip.SetDefault("Restores 120 stamina");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.consumable = true;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 17;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina = 120;
            item.maxStack = 99;
            item.value = 4000;
            item.useAnimation = 17;
            item.height = dims.Height;
            item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<GreaterStaminaPotion>(), 2);
            recipe.AddIngredient(ItemID.SharkFin, 6);
            recipe.AddIngredient(ItemID.Mushroom);
            recipe.AddIngredient(ItemID.Silk);
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
            player.Avalon().statStam += 120;
            player.Avalon().StaminaHealEffect(120, true);
            if (player.Avalon().statStam > player.Avalon().statStamMax2)
            {
                player.Avalon().statStam = player.Avalon().statStamMax2;
            }
            return true;
        }
    }
}
