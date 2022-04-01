using ExxoAvalonOrigins.Items.Fish;
using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
    public class FuryPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fury Potion");
            Tooltip.SetDefault("Increases critical strike damage by 20%");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.buffType = ModContent.BuffType<Buffs.Fury>();
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.width = dims.Width;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.maxStack = 100;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.useAnimation = 15;
            Item.height = dims.Height;
            Item.buffTime = 14400;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.BottledWater).AddIngredient(ModContent.ItemType<Ickfish>()).AddIngredient(ModContent.ItemType<Barfbush>()).AddTile(TileID.Bottles).ReplaceResult(ModContent.ItemType<FuryPotion>());
        }
    }
}
