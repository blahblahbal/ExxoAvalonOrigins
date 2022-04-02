using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ExxoAvalonOrigins.Items.Weapons.Summon;

public class UltrablivionStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ultrablivion Staff");
        Tooltip.SetDefault("Summons a mini Ultrablivion to fight for you");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.DamageType = DamageClass.Summon;
        Item.mana = 5;
        Item.width = 152;
        Item.height = 152;
        Item.useAnimation = 30;
        Item.useTime = 30;
        Item.useStyle = 1;
        Item.noMelee = true;
        Item.damage = 100;
        Item.knockBack = 4;
        Item.value = Item.buyPrice(10, 0, 0, 0);
        Item.rare = 11;
        Item.expert = true;
        Item.UseSound = SoundID.Item44;
        Item.shoot = ModContent.ProjectileType<Projectiles.Summon.UltraHMinion>();
        Item.shootSpeed = 10f;
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

    public override bool? UseItem(Player player)
    {
        if (player.altFunctionUse == 2)
        {
            player.MinionNPCTargetAim();
        }
        return base.UseItem(player);
    }
}