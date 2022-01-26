using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ExxoAvalonOrigins.Items.Weapons.Summon
{
    public class UltrablivionStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultrablivion Staff");
            Tooltip.SetDefault("Summons a mini Ultrablivion to fight for you");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.summon = true;
            item.mana = 5;
            item.width = 152;
            item.height = 152;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 1;
            item.noMelee = true;
            item.damage = 100;
            item.knockBack = 4;
            item.value = Item.buyPrice(10, 0, 0, 0);
            item.rare = 11;
            item.expert = true;
            item.UseSound = SoundID.Item44;
            item.shoot = ModContent.ProjectileType<Projectiles.Summon.UltraHMinion>();
            item.shootSpeed = 10f;
        }

        
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse != 2)
            {
                Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<Projectiles.Summon.UltraHMinion>(), damage, knockBack, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<Projectiles.Summon.UltraRMinion>(), damage, knockBack, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(position + new Vector2(100, 0), new Vector2(speedX, speedY), ModContent.ProjectileType<Projectiles.Summon.UltraLMinion>(), damage, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }
    }
}
