using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged;

class SunsShadow : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sun's Shadow");
        Tooltip.SetDefault("Fires a spread of twelve seeds\nAllows the collection of seeds for ammo");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 21;
        Item.autoReuse = true;
        Item.useAmmo = AmmoID.Dart;
        Item.UseSound = SoundID.Item63;
        Item.shootSpeed = 11f;
        Item.DamageType = DamageClass.Ranged;
        Item.rare = ItemRarityID.Yellow;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 28;
        Item.knockBack = 4f;
        Item.shoot = ProjectileID.PurificationPowder;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 10000;
        Item.useAnimation = 28;
        Item.height = dims.Height;
    }

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
                               ref float knockBack)
    {
        for (int num203 = 0; num203 < 12; num203++)
        {
            float num204 = speedX;
            float num205 = speedY;
            num204 += (float)Main.rand.Next(-35, 36) * 0.05f;
            num205 += (float)Main.rand.Next(-35, 36) * 0.05f;
            Projectile.NewProjectile(position.X, position.Y, num204, num205, type, damage, knockBack, player.whoAmI, 0f, 0f);
        }

        return false;
    }
}