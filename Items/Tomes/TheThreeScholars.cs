using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes
{
    class TheThreeScholars : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Three Scholars");
            Tooltip.SetDefault("Tome\n+20 defense");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.value = 150000;
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 20;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 10);
            recipe.AddIngredient(ItemID.IronskinPotion, 10);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<VorazylcumBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 10);
            recipe.AddIngredient(ItemID.IronskinPotion, 10);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
