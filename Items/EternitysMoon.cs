using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items
{
    class EternitysMoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eternity's Moon");
            Tooltip.SetDefault("+20 mana, -5% mana cost");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/EternitysMoon");
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.value = 15000;
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 20;
            player.manaCost -= 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ModContent.ItemType<Gravel>(), 15);
            recipe.AddIngredient(ModContent.ItemType<MysticalClaw>(), 2);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>());
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}