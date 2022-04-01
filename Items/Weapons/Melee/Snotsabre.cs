using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class Snotsabre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snotsabre");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item1;
            Item.damage = 17;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.1f;
            Item.rare = ItemRarityID.Blue;
            Item.width = dims.Width;
            Item.useTime = 20;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 0, 36, 0);
            Item.useAnimation = 20;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 10).AddTile(TileID.Anvils).Register();
        }
    }
}
