using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class TheHeavenlyScent : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Heavenly Scent");
            Tooltip.SetDefault("Tome\n+2 life regen");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.value = 150000;
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RubybeadHerb>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Sandstone>(), 3);
            recipe.AddIngredient(ItemID.LesserHealingPotion, 5);
            recipe.AddIngredient(ItemID.BandofRegeneration);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
