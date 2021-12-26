using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    public class ShellHammer : ModItem
    {
        int fireDelay = 240;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shell Hammer");
            Tooltip.SetDefault("Lobs shells");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 56;
            //item.projFireDelay = 240;
            item.knockBack = 12f;
            item.melee = item.useTurn = item.autoReuse = true;
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.useStyle = item.maxStack = 1;
            item.useAnimation = item.useTime = 35;
            item.shoot = ModContent.ProjectileType<Projectiles.Shell>();
            item.shootSpeed = 5.5f;
            item.damage = 87;
            item.value = Item.sellPrice(0, 6, 20, 0);
        }
        //public override void HoldItem(Player player)
        //{
        //    if (player.itemAnimation > 0 && fireDelay > 0)
        //    {
        //        fireDelay--;
        //    }
        //    if (fireDelay == 0)
        //    {
        //        Projectile.NewProjectile(player.position, new Vector2(7f, 6f), ModContent.ProjectileType<Projectiles.Shell>(), (int)(87 * player.meleeDamage), 6f);
        //        fireDelay = 240;
        //    }
        //}
    }
}
