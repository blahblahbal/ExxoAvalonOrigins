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
            Item.damage = 100;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 15f;
            Item.DamageType = DamageClass.Ranged;
            Item.rare = ItemRarityID.Cyan;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.knockBack = 5f;
            Item.useTime = 15;
            Item.shoot = ModContent.ProjectileType<Projectiles.ArrowBeam>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.useAnimation = 15;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item5;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileID.ShadowBeamFriendly, damage, knockBack);
            // Main.projectile[proj].magic = false /* tModPorter - this is redundant, for more info see https://github.com/tModLoader/tModLoader/wiki/Update-Migration-Guide#damage-classes */ ;
            Main.projectile[proj].DamageType = DamageClass.Ranged;
            return false;
        }
    }
}
