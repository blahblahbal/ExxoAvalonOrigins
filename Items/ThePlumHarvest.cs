using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items
{
    class ThePlumHarvest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Plum Harvest");
            Tooltip.SetDefault("Tome\n30% chance to not consume ammo");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/ThePlumHarvest");
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.value = 150000;
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        //Update Accs not needed - ammo done in ModPlayer

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<Opal>(), 50);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 30);
            recipe.AddIngredient(ItemID.ShroomiteBar, 12);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}