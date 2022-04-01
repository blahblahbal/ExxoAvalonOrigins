using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
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
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25));
                //float scale = 1f - (Main.rand.NextFloat() * .3f);
                //perturbedSpeed = perturbedSpeed * scale; 
                int spirit = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                // Main.projectile[spirit].magic = false /* tModPorter - this is redundant, for more info see https://github.com/tModLoader/tModLoader/wiki/Update-Migration-Guide#damage-classes */ ;
                Main.projectile[spirit].DamageType = DamageClass.Melee;
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
        public override bool OnlyShootOnSwing => base.OnlyShootOnSwing;
    }
}
