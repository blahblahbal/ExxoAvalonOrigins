using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items
{
    class TomeofDistance : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome of Distance");
            Tooltip.SetDefault("Tome\n+15% ranged damage, +40 HP, +20 mana\n20% chance to not consume ammo");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/TomeofDistance");
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.value = 15000;
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedDamage += 0.15f;
            player.statLifeMax2 += 40;
            player.statManaMax2 += 20;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MistyPeachBlossoms>());
            recipe.AddIngredient(ModContent.ItemType<TaleoftheRedLotus>());
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>());
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}