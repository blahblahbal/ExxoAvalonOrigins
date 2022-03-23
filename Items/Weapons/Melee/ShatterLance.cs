using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class ShatterLance : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shatter Lance");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item1;
            item.damage = 171;
            item.noUseGraphic = true;
            item.scale = 1.1f;
            item.shootSpeed = 5f;
            item.rare = ItemRarityID.Pink;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 16;
            item.knockBack = 5.6f;
            item.shoot = ModContent.ProjectileType<Projectiles.Melee.ShatterLance>();
            item.melee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 105000;
            item.useAnimation = 16;
            item.height = dims.Height;
            item.autoReuse = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 pos = player.Center + new Vector2(100, 0).RotatedBy(player.AngleTo(Main.MouseWorld));
            Projectile.NewProjectile(pos.X, pos.Y, speedX * 3, speedY * 3, ModContent.ProjectileType<Projectiles.Melee.ShatterShard>(), damage, knockBack, player.whoAmI);
            return true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 150);
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}
