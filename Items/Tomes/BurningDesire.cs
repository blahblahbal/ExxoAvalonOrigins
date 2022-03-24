using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes
{
    class BurningDesire : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Burning Desire");
            Tooltip.SetDefault("Tome\n+40 HP\n+40 mana");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.value = 15000;
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 40;
            player.statManaMax2 += 40;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Gravel>(), 7);
            recipe.AddIngredient(ModContent.ItemType<RubybeadHerb>(), 3);
            recipe.AddIngredient(ItemID.LifeCrystal);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 4);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
