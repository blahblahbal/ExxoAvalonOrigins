using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
    class StrengthPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strength Potion");
            Tooltip.SetDefault("Increases all stats");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.buffType = ModContent.BuffType<Buffs.Strong>();
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.useTime = 15;
            Item.value = 2000;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.maxStack = 100;
            Item.useAnimation = 15;
            Item.height = dims.Height;
            Item.buffTime = 32400;
            Item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.BottledLava>()).AddIngredient(ItemID.TitaniumBar).AddIngredient(ItemID.Diamond).AddTile(TileID.Bottles).Register();
        }
    }
}
