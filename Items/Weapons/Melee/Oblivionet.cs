using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class Oblivionet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oblivionet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 70;
            item.autoReuse = true;
            item.useTurn = true;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.knockBack = 6.2f;
            item.useTime = 21;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.useAnimation = 21;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ExcaliburNet>());
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
