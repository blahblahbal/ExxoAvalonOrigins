using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
    class GPSPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GPS Potion");
            Tooltip.SetDefault("GPS Effect");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.buffType = ModContent.BuffType<Buffs.GPS>();
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.width = dims.Width;
            Item.useTime = 15;
            Item.value = 2000;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.maxStack = 100;
            Item.useAnimation = 15;
            Item.height = dims.Height;
            Item.buffTime = 18000;
            Item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.BottledWater).AddIngredient(ModContent.ItemType<Placeable.Tile.Beak>()).AddIngredient(ItemID.IronOre).AddIngredient(ModContent.ItemType<Material.RottenEye>()).AddTile(TileID.Bottles).Register();
            CreateRecipe(1).AddIngredient(ItemID.BottledWater).AddIngredient(ModContent.ItemType<Placeable.Tile.Beak>()).AddIngredient(ItemID.LeadOre).AddIngredient(ModContent.ItemType<Material.RottenEye>()).AddTile(TileID.Bottles).Register();
            CreateRecipe(1).AddIngredient(ItemID.BottledWater).AddIngredient(ModContent.ItemType<Placeable.Tile.Beak>()).AddIngredient(ItemID.IronOre).AddIngredient(ModContent.ItemType<Material.Patella>()).AddTile(TileID.Bottles).Register();
            CreateRecipe(1).AddIngredient(ItemID.BottledWater).AddIngredient(ModContent.ItemType<Placeable.Tile.Beak>()).AddIngredient(ItemID.LeadOre).AddIngredient(ModContent.ItemType<Material.Patella>()).AddTile(TileID.Bottles).Register();
        }
    }
}
