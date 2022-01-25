using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
    class CrimsonPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aura Potion");
            Tooltip.SetDefault("On-screen enemies take damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.buffType = ModContent.BuffType<Buffs.CrimsonDrain>();
            item.consumable = true;
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.maxStack = 100;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.useAnimation = 15;
            item.height = dims.Height;
            item.buffTime = 18000;
            item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddIngredient(ItemID.Spike);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Material.Barfbush>());
            recipe.AddIngredient(ItemID.Spike);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Material.Bloodberry>());
            recipe.AddIngredient(ItemID.Spike);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
