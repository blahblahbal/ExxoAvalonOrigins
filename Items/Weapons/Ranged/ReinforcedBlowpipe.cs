using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class ReinforcedBlowpipe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reinforced Blowpipe");
            Tooltip.SetDefault("Fires a spread of two seeds\nAllows the collection of seeds for ammo");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 11;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Dart;
            Item.UseSound = SoundID.Item63;
            Item.shootSpeed = 11f;
            Item.DamageType = DamageClass.Ranged;
            Item.rare = ItemRarityID.Blue;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 40;
            Item.knockBack = 3.25f;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 10000;
            Item.useAnimation = 40;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item5;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddRecipeGroup("ExxoAvalonOrigins:SilverBar", 5).AddIngredient(ItemID.Blowpipe).AddTile(TileID.Anvils).Register();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            for (int num197 = 0; num197 < 2; num197++)
            {
                float num198 = speedX;
                float num199 = speedY;
                num198 += (float)Main.rand.Next(-35, 36) * 0.05f;
                num199 += (float)Main.rand.Next(-35, 36) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, num198, num199, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }

            return false;
        }
    }
}
