using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
    class LuckPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Luck Potion");
            Tooltip.SetDefault("Doubles rare drop chance");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.buffType = ModContent.BuffType<Buffs.Luck>();
            item.consumable = true;
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.maxStack = 100;
            item.useAnimation = 15;
            item.height = dims.Height;
            item.buffTime = 108000;
            item.UseSound = SoundID.Item3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.FakeFourLeafClover>());
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Material.Holybird>());
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<LuckPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.FourLeafClover>());
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Material.Holybird>(), 20);
            recipe.AddIngredient(ItemID.Fireblossom, 20);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<LuckPotion>(), 20);
            recipe.AddRecipe();
        }
    }
}
