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
            item.useStyle = 1;
            item.shootSpeed = 14f;
            item.shoot = ModContent.ProjectileType<Projectiles.Reflector>();
            item.damage = 120;
            item.width = 38;
            item.height = 36;
            item.UseSound = SoundID.Item44;
            item.buffType = ModContent.BuffType<Buffs.Reflector>();
            item.useAnimation = 30;
            item.useTime = 30;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 30, 0, 0);
            item.knockBack = 8.5f;
            item.rare = 8;
            item.summon = true;
            item.mana = 30;
        }
    }
}
