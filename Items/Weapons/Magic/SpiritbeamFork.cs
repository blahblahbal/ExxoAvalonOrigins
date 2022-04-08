using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class SpiritbeamFork : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Spiritbeam Fork");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Magic;
        Item.damage = 60;
        Item.autoReuse = true;
        Item.shootSpeed = 6f;
        Item.mana = 15;
        Item.rare = ItemRarityID.Cyan;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 19;
        Item.knockBack = 4.25f;
        Item.shoot = ProjectileID.ShadowBeamFriendly;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = Item.sellPrice(0, 30, 0, 0);
        Item.useAnimation = 19;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item43;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.InfernoFork).AddIngredient(ItemID.SpectreStaff).AddIngredient(ItemID.ShadowbeamStaff).AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 20).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int num172 = 0; num172 < 3; num172++)
        {
            float num173 = velocity.X;
            float num174 = velocity.Y;
            num173 += (float)Main.rand.Next(-30, 31) * 0.05f;
            num174 += (float)Main.rand.Next(-30, 31) * 0.05f;
            switch (num172)
            {
                case 0:
                    Projectile.NewProjectile(source, position.X, position.Y, num173, num174, ProjectileID.InfernoFriendlyBolt, damage, knockback, player.whoAmI, 0f, 0f);
                    break;
                case 1:
                    Projectile.NewProjectile(source, position.X, position.Y, num173, num174, ProjectileID.LostSoulFriendly, damage, knockback, player.whoAmI, 0f, 0f);
                    break;
                case 2:
                    Projectile.NewProjectile(source, position.X, position.Y, num173, num174, ProjectileID.ShadowBeamFriendly, damage, knockback, player.whoAmI, 0f, 0f);
                    break;
            }
        }

        return false;
    }
}
