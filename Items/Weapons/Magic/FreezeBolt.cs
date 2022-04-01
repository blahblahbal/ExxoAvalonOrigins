using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class FreezeBolt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freeze Bolt");
            Tooltip.SetDefault("Casts a fast-moving bolt of ice");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.DamageType = DamageClass.Magic;
            Item.damage = 43;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.shootSpeed = 7f;
            Item.mana = 11;
            Item.rare = ItemRarityID.Pink;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 17;
            Item.knockBack = 5f;
            Item.shoot = ModContent.ProjectileType<Projectiles.FreezeBolt>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 50000;
            Item.useAnimation = 17;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item21;
        }
    }
}
