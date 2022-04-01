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
            Item.buffType = ModContent.BuffType<Buffs.Gauntlet>();
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.maxStack = 100;
            Item.useAnimation = 15;
            Item.height = dims.Height;
            Item.buffTime = 18000;
            Item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ModContent.ItemType<Material.Sweetstem>()).AddIngredient(ItemID.Deathweed).AddIngredient(ItemID.IronOre, 3).AddTile(TileID.Bottles).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ModContent.ItemType<Material.Sweetstem>()).AddIngredient(ModContent.ItemType<Material.Bloodberry>()).AddIngredient(ItemID.IronOre, 3).AddTile(TileID.Bottles).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ModContent.ItemType<Material.Sweetstem>()).AddIngredient(ItemID.Deathweed).AddIngredient(ItemID.LeadOre, 3).AddTile(TileID.Bottles).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ModContent.ItemType<Material.Sweetstem>()).AddIngredient(ModContent.ItemType<Material.Bloodberry>()).AddIngredient(ItemID.LeadOre, 3).AddTile(TileID.Bottles).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ModContent.ItemType<Material.Sweetstem>()).AddIngredient(ModContent.ItemType<Material.Barfbush>()).AddIngredient(ItemID.IronOre, 3).AddTile(TileID.Bottles).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ModContent.ItemType<Material.Sweetstem>()).AddIngredient(ModContent.ItemType<Material.Barfbush>()).AddIngredient(ItemID.LeadOre, 3).AddTile(TileID.Bottles).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ModContent.ItemType<Material.Sweetstem>()).AddIngredient(ItemID.Deathweed).AddIngredient(ModContent.ItemType<Placeable.Tile.NickelOre>(), 3).AddTile(TileID.Bottles).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ModContent.ItemType<Material.Sweetstem>()).AddIngredient(ModContent.ItemType<Material.Bloodberry>()).AddIngredient(ModContent.ItemType<Placeable.Tile.NickelOre>(), 3).AddTile(TileID.Bottles).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ModContent.ItemType<Material.Sweetstem>()).AddIngredient(ModContent.ItemType<Material.Barfbush>()).AddIngredient(ModContent.ItemType<Placeable.Tile.NickelOre>(), 3).AddTile(TileID.Bottles).Register();
        }
    }
}
