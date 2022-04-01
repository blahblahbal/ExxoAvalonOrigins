using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class GoldminePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goldmine Pickaxe");
            Tooltip.SetDefault("Able to mine Hellstone");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item1;
            Item.damage = 10;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.15f;
            Item.pick = 69;
            Item.rare = ItemRarityID.Blue;
            Item.width = dims.Width;
            Item.useTime = 13;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 0, 36, 0);
            Item.useAnimation = 21;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 12).AddIngredient(ModContent.ItemType<Material.Booger>(), 6).AddTile(TileID.Anvils).Register();
        }
    }
}
