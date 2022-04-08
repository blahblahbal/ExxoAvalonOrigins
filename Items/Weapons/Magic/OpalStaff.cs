using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class OpalStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Opal Staff");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.SapphireStaff);
        Item.staff[Item.type] = true;
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.damage = 90;
        Item.autoReuse = true;
        Item.shootSpeed = 9.5f;
        Item.mana = 14;
        Item.rare = ItemRarityID.Yellow;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.knockBack = 7.5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.OpalBolt>();
        Item.value = Item.buyPrice(0, 30, 0, 0);
        Item.UseSound = SoundID.Item43;
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int num182 = 0; num182 < 3; num182++)
        {
            float num183 = velocity.X;
            float num184 = velocity.Y;
            num183 += (float)Main.rand.Next(-30, 31) * 0.05f;
            num184 += (float)Main.rand.Next(-30, 31) * 0.05f;
            Projectile.NewProjectile(source, position.X, position.Y, num183, num184, type, damage, knockback, player.whoAmI, 0f, 0f);
        }

        return false;
    }
}
