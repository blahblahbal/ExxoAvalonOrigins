using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class ZincBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Bow");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item5;
            item.damage = 12;
            item.useTurn = true;
            item.scale = 1f;
            item.shootSpeed = 6.5f;
            item.useAmmo = AmmoID.Arrow;
            item.ranged = item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 25;
            item.knockBack = 0f;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 2200;
            item.useAnimation = 25;
            item.height = dims.Height;
        }
    }
}
