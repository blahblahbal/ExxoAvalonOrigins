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
            item.magic = true;
            item.damage = 95;
            item.mana = 14;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.shootSpeed = 15f;
            item.noMelee = true;
            item.rare = ItemRarityID.Purple;
            item.width = dims.Width;
            item.useTime = 18;
            item.knockBack = 3.75f;
            item.shoot = ModContent.ProjectileType<Projectiles.BlahKnife>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 50);
            item.useAnimation = 18;
            item.height = dims.Height;
            item.UseSound = SoundID.Item39;
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
