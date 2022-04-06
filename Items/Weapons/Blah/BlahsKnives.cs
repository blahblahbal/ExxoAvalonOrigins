using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Blah;

class BlahsKnives : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blah's Knives");
        Tooltip.SetDefault("Rapidly throws lifestealing daggers that seek out targets and compound damage upon hits");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Magic;
        Item.damage = 95;
        Item.mana = 14;
        Item.noUseGraphic = true;
        Item.autoReuse = true;
        Item.shootSpeed = 15f;
        Item.noMelee = true;
        Item.rare = ModContent.RarityType<Rarities.BlahRarity>();
        Item.width = dims.Width;
        Item.useTime = 18;
        Item.knockBack = 3.75f;
        Item.shoot = ModContent.ProjectileType<Projectiles.BlahKnife>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 50);
        Item.useAnimation = 18;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item39;
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        int numberProjectiles = ExxoAvalonOriginsGlobalProjectile.howManyProjectiles(4, 8);
        for (int i = 0; i < numberProjectiles; i++)
        {
            Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20));
            Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
        }
        return false;
    }
}
