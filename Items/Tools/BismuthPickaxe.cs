using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class BismuthPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Pickaxe");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item1;
            Item.damage = 6;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1f;
            Item.pick = 59;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 14000;
            Item.useAnimation = 14;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 12).AddIngredient(ItemID.Wood, 4).AddTile(TileID.Anvils).Register();
        }
    }
}
