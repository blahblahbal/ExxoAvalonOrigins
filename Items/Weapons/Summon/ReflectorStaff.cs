using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Summon
{
    public class ReflectorStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reflector Staff");
            Tooltip.SetDefault("Summons mirrors to reflect hostile projectiles");
        }
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.shootSpeed = 14f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Reflector>();
            Item.damage = 120;
            Item.width = 38;
            Item.height = 36;
            Item.UseSound = SoundID.Item44;
            //item.buffType = ModContent.BuffType<Buffs.Reflector>();
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.noMelee = true;
            Item.value = Item.sellPrice(0, 30, 0, 0);
            Item.knockBack = 8.5f;
            Item.rare = 8;
            Item.DamageType = DamageClass.Summon;
            Item.mana = 30;
            //item.buffTime = 3600;
        }
    }
}
