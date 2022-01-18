using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class Wheezebow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wheezebow");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item5;
            item.damage = 16;
            item.useTurn = true;
            item.scale = 1.1f;
            item.shootSpeed = 9f;
            item.useAmmo = AmmoID.Arrow;
            item.ranged = item.noMelee = true;
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.useTime = 20;
            item.knockBack = 0f;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 0, 36, 0);
            item.useAnimation = 20;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 9);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
