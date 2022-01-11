using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    class BismuthCrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Crown");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.vanity = true;
            item.width = dims.Width;
            item.value = 15000;
            item.height = dims.Height;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 5);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.SlimeCrown);
        }
    }
}
