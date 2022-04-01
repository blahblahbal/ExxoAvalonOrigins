using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class RhodiumGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rhodium Greatsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 25;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.5f;
            Item.crit += 5;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.useTime = 25;
            Item.knockBack = 5f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 50000;
            Item.useAnimation = 20;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.RhodiumBar>(), 14).AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 3).AddTile(TileID.Anvils).Register();
        }
    }
}
