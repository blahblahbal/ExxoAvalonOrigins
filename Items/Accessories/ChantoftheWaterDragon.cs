using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class ChantoftheWaterDragon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chant of the Water Dragon");
            Tooltip.SetDefault("Tome\n+20% magic damage");
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
            player.magicDamage += 0.2f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 30);
            recipe.AddIngredient(ItemID.FallenStar, 100);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
