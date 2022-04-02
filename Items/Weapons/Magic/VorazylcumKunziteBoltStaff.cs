using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class VorazylcumKunziteBoltStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Vorazylcum-Kunzite Bolt Staff");
        Tooltip.SetDefault("Fires a spread of magical bolts");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.SapphireStaff);
        Item.staff[Item.type] = true;
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.damage = 92;
        Item.autoReuse = true;
        Item.shootSpeed = 6f;
        Item.mana = 37;
        Item.rare = ItemRarityID.Cyan;
        Item.knockBack = 3f;
        Item.useTime = 40;
        Item.useAnimation = 40;
        Item.shoot = ModContent.ProjectileType<Projectiles.KunziteBolt>();
        Item.value = Item.sellPrice(0, 60, 0, 0);
        Item.UseSound = SoundID.Item43;
    }

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
                               ref float knockBack)
    {
        for (int num161 = 0; num161 < 10; num161++)
        {
            float num162 = speedX;
            float num163 = speedY;
            num162 += (float)Main.rand.Next(-30, 31) * 0.05f;
            num163 += (float)Main.rand.Next(-30, 31) * 0.05f;
            Projectile.NewProjectile(position.X, position.Y, num162, num163, type, damage, knockBack, player.whoAmI, 0f, 0f);
        }

        return false;
    }
}