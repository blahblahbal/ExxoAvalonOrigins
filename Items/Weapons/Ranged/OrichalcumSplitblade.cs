using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged;

class OrichalcumSplitblade : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Orichalcum Splitblade");
        Tooltip.SetDefault("Splits into three knives");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.noUseGraphic = true;
        Item.damage = 31;
        Item.maxStack = 999;
        Item.shootSpeed = 10f;
        Item.crit += 1;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.noMelee = true;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 18;
        Item.knockBack = 2f;
        Item.shoot = ModContent.ProjectileType<Projectiles.OrichalcumBlade>();
        Item.value = 250;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 18;
        Item.height = dims.Height;
    }

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
                               ref float knockBack)
    {
        for (int num215 = 0; num215 < 3; num215++)
        {
            float num216 = speedX;
            float num217 = speedY;
            num216 += (float)Main.rand.Next(-40, 41) * 0.05f;
            num217 += (float)Main.rand.Next(-40, 41) * 0.05f;
            Projectile.NewProjectile(position.X, position.Y, num216, num217, type, damage, knockBack, player.whoAmI, 0f, 0f);
        }

        return false;
    }
}