using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class SoulEdge : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Soul Edge");
        Tooltip.SetDefault("'Haunted by souls of darkness'");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item1;
        Item.damage = 83;
        Item.autoReuse = true;
        Item.scale = 1.1f;
        Item.shootSpeed = 8f;
        Item.rare = ItemRarityID.Yellow;
        Item.noMelee = false;
        Item.width = dims.Width;
        Item.useTime = 20;
        Item.knockBack = 6.5f;
        Item.shoot = ProjectileID.LostSoulFriendly;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 80, 0, 0);
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255, 150);
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        int numberProjectiles = 2 + Main.rand.Next(2); // 4 or 5 shots
        for (int i = 0; i < numberProjectiles; i++)
        {
            Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(25));
            int spirit = Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            Main.projectile[spirit].DamageType = DamageClass.Melee;
        }
        return false; // return false because we don't want tmodloader to shoot projectile
    }
    public override bool OnlyShootOnSwing => base.OnlyShootOnSwing;
}
