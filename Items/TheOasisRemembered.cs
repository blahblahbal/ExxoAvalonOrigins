using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items
{
    class TheOasisRemembered : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Oasis Remembered");
            Tooltip.SetDefault("Tome\n20% increased minion damage and knockback");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/TheOasisRemembered");
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 40);
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.minionDamage += 0.2f;
            player.minionKB += 0.2f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 30);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}