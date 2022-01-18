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
            item.buffType = ModContent.BuffType<Buffs.Shockwave>();
            item.consumable = true;
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.maxStack = 100;
            item.value = 1000;
            item.useAnimation = 15;
            item.height = dims.Height;
            item.buffTime = 25200;
            item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BottledLava>());
            recipe.AddIngredient(ItemID.Meteorite);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
