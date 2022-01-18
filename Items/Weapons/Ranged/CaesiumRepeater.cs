using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class CaesiumRepeater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caesium Crossbow");
            Tooltip.SetDefault("Converts wooden arrows into hellfire arrows");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item5;
            item.UseSound = SoundID.Item5;
            item.damage = 53;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 16f;
            item.ranged = true;
            item.noMelee = true;
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.useTime = 16;
            item.knockBack = 2.75f;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 75000;
            item.useAnimation = 16;
            item.height = dims.Height;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ProjectileID.HellfireArrow;
            }
            return true;
        }
    }
}
