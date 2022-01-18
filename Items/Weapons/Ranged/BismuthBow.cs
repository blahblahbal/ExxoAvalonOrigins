using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class BismuthBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Bow");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item5;
            item.damage = 13;
            item.useTurn = true;
            item.scale = 1f;
            item.shootSpeed = 8f;
            item.useAmmo = AmmoID.Arrow;
            item.ranged = item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 20;
            item.knockBack = 0f;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 4600;
            item.useAnimation = 20;
            item.height = dims.Height;
        }
    }
}
