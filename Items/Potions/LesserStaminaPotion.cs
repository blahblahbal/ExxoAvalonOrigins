using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
    class LesserStaminaPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lesser Stamina Potion");
            Tooltip.SetDefault("Restores 35 stamina");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.consumable = true;
            Item.width = dims.Width;
            Item.useTurn = true;
            Item.useTime = 17;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina = 35;
            Item.maxStack = 30;
            Item.value = 400;
            Item.useAnimation = 17;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.BottledWater).AddIngredient(ModContent.ItemType<Placeable.Tile.Boltstone>()).AddIngredient(ItemID.Cactus, 2).AddTile(TileID.Bottles).Register();
        }
        public override bool CanUseItem(Player player)
        {
            if (player.Avalon().statStam >= player.Avalon().statStamMax2) return false;
            return true;
        }
        public override bool? UseItem(Player player)
        {
            player.Avalon().statStam += 35;
            player.Avalon().StaminaHealEffect(35, true);
            if (player.Avalon().statStam > player.Avalon().statStamMax2)
            {
                player.Avalon().statStam = player.Avalon().statStamMax2;
            }
            return true;
        }
    }
}
