using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
    class ShockwavePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shockwave Potion");
            Tooltip.SetDefault("Enemies take damage when you land");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.buffType = ModContent.BuffType<Buffs.Shockwave>();
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.maxStack = 100;
            Item.value = 1000;
            Item.useAnimation = 15;
            Item.height = dims.Height;
            Item.buffTime = 25200;
            Item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ItemID.Meteorite).AddIngredient(ItemID.Blinkroot).AddTile(TileID.Bottles).Register();
        }
    }
}
