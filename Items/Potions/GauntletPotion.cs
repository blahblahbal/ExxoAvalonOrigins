using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
    class GauntletPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gauntlet Potion");
            Tooltip.SetDefault("-6 defense, +12% melee damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.buffType = ModContent.BuffType<Buffs.Gauntlet>();
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.maxStack = 100;
            item.useAnimation = 15;
            item.height = dims.Height;
            item.buffTime = 18000;
            item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Material.Sweetstem>());
            recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddIngredient(ItemID.IronOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Material.Sweetstem>());
            recipe.AddIngredient(ModContent.ItemType<Material.Bloodberry>());
            recipe.AddIngredient(ItemID.IronOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Material.Sweetstem>());
            recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddIngredient(ItemID.LeadOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Material.Sweetstem>());
            recipe.AddIngredient(ModContent.ItemType<Material.Bloodberry>());
            recipe.AddIngredient(ItemID.LeadOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Material.Sweetstem>());
            recipe.AddIngredient(ModContent.ItemType<Material.Barfbush>());
            recipe.AddIngredient(ItemID.IronOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Material.Sweetstem>());
            recipe.AddIngredient(ModContent.ItemType<Material.Barfbush>());
            recipe.AddIngredient(ItemID.LeadOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Material.Sweetstem>());
            recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.NickelOre>(), 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Material.Sweetstem>());
            recipe.AddIngredient(ModContent.ItemType<Material.Bloodberry>());
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.NickelOre>(), 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Material.Sweetstem>());
            recipe.AddIngredient(ModContent.ItemType<Material.Barfbush>());
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.NickelOre>(), 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
