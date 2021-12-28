using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Crafting
{
    internal class SeedFabricator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seed Fabricator");
            Tooltip.SetDefault("Used to fabricate most seeds");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.SeedFabricator>();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 0, 20);
            item.useAnimation = 15;
            item.height = dims.Height;
        }
        //public override void AddRecipes()
        //{
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(ItemID.HeavyWorkBench);
        //    recipe.AddIngredient(ItemID.Marble, 10);
        //    recipe.AddIngredient(ModContent.ItemType<EarthShard>(), 3);
        //    recipe.AddTile(TileID.Anvils);
        //    recipe.SetResult(this);
        //    recipe.AddRecipe();
        //}
    }
}
