using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged;

class OrichythrilBlowpipe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Lyonic Blowpipe");
        Tooltip.SetDefault("Fires a spread of seven seeds\nAllows the collection of seeds for ammo");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 13;
        Item.autoReuse = true;
        Item.useAmmo = AmmoID.Dart;
        Item.UseSound = SoundID.Item63;
        Item.shootSpeed = 11f;
        Item.DamageType = DamageClass.Ranged;
        Item.rare = ItemRarityID.LightRed;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 30;
        Item.knockBack = 3.25f;
        Item.shoot = ProjectileID.PurificationPowder;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 10000;
        Item.useAnimation = 30;
        Item.height = dims.Height;
    }

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
                               ref float knockBack)
    {
        for (int num206 = 0; num206 < 7; num206++)
        {
            float num207 = speedX;
            float num208 = speedY;
            num207 += (float)Main.rand.Next(-35, 36) * 0.05f;
            num208 += (float)Main.rand.Next(-35, 36) * 0.05f;
            Projectile.NewProjectile(position.X, position.Y, num207, num208, type, damage, knockBack, player.whoAmI, 0f, 0f);
        }

        return false;
    }
}