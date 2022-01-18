using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class VorazylcumFusebow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vorazylcum Fusebow");
            Tooltip.SetDefault("Fires a beam of energy");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 100;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 15f;
            item.ranged = true;
            item.rare = ItemRarityID.Cyan;
            item.noMelee = true;
            item.width = dims.Width;
            item.knockBack = 5f;
            item.useTime = 15;
            item.shoot = ModContent.ProjectileType<Projectiles.ArrowBeam>();
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.useAnimation = 15;
            item.height = dims.Height;
            item.UseSound = SoundID.Item5;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileID.ShadowBeamFriendly, damage, knockBack);
            Main.projectile[proj].magic = false;
            Main.projectile[proj].ranged = true;
            return false;
        }
    }
}
