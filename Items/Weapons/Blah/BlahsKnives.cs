using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Blah
{
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
            Item.rare = ItemRarityID.Purple;
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
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = ExxoAvalonOriginsGlobalProjectile.howManyProjectiles(4, 8);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
