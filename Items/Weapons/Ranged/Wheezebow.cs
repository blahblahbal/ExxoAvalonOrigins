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
            Item.UseSound = SoundID.Item5;
            Item.damage = 16;
            Item.useTurn = true;
            Item.scale = 1.1f;
            Item.shootSpeed = 9f;
            Item.useAmmo = AmmoID.Arrow;
            Item.DamageType = // item.noMelee = true /* tModPorter - this is redundant, for more info see https://github.com/tModLoader/tModLoader/wiki/Update-Migration-Guide#damage-classes */ ;
            Item.rare = ItemRarityID.Blue;
            Item.width = dims.Width;
            Item.useTime = 20;
            Item.knockBack = 0f;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.sellPrice(0, 0, 36, 0);
            Item.useAnimation = 20;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 9).AddTile(TileID.Anvils).Register();
        }
    }
}
