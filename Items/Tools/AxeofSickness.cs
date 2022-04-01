using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class AxeofSickness : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Axe of Sickness");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item1;
            Item.damage = 24;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.2f;
            Item.axe = 15;
            Item.rare = ItemRarityID.Blue;
            Item.width = dims.Width;
            Item.useTime = 34;
            Item.knockBack = 6f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 0, 36, 0);
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 34;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 10).AddTile(TileID.Anvils).Register();
        }
    }
}
