using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
    class HellboundRemote : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellbound Remote");
            Tooltip.SetDefault("Summons the Wall of Steel\nToss into lava in the Underworld");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.LightPurple;
            item.width = dims.Width;
            item.maxStack = 1;
            item.value = 0;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EarthStone>());
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddIngredient(ModContent.ItemType<GhostintheMachine>());
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ModContent.ItemType<FleshyTendril>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.HallowedAltar>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
