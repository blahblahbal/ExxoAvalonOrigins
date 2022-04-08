using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class Mechazapinator : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Mechazapinator");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Magic;
        Item.damage = 107;
        Item.autoReuse = true;
        Item.shootSpeed = 15f;
        Item.mana = 20;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.knockBack = 2f;
        Item.useTime = 20;
        Item.shoot = ModContent.ProjectileType<Projectiles.ElectricBolt>();
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = Item.sellPrice(0, 10);
        Item.useAnimation = 20;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item12;
    }
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-10f, 0f);
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int num182 = 0; num182 < 3; num182++)
        {
            float num183 = velocity.X;
            float num184 = velocity.Y;
            num183 += Main.rand.Next(-30, 31) * 0.1f;
            num184 += Main.rand.Next(-30, 31) * 0.1f;
            int proj = Projectile.NewProjectile(source, position.X, position.Y, num183, num184, type, damage, knockback, player.whoAmI, 0f, 0f);
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].friendly = true;
        }
        return false;
    }
}
