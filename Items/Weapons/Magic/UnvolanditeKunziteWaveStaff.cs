using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class UnvolanditeKunziteWaveStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Unvolandite-Kunzite Wave Staff");
        Tooltip.SetDefault("Sprays out a wave of showers");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Magic;
        Item.damage = 90;
        Item.autoReuse = true;
        Item.shootSpeed = 15f;
        Item.mana = 30;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.knockBack = 3f;
        Item.useTime = 25;
        Item.shoot = ModContent.ProjectileType<Projectiles.KunziteShower>();
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = Item.sellPrice(0, 60, 0, 0);
        Item.useAnimation = 25;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item43;
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int num158 = 0; num158 < 6; num158++)
        {
            float num159 = velocity.X;
            float num160 = velocity.Y;
            num159 += (float)Main.rand.Next(-40, 41) * 0.05f;
            num160 += (float)Main.rand.Next(-40, 41) * 0.05f;
            Projectile.NewProjectile(source, position.X, position.Y, num159, num160, type, damage, knockback, player.whoAmI, 0f, 0f);
        }
        return false;
    }
}
