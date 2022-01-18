using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class RhodiumLongbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rhodium Longbow");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item5;
            item.damage = 21;
            item.useTurn = true;
            item.scale = 1f;
            item.shootSpeed = 9f;
            item.useAmmo = AmmoID.Arrow;
            item.ranged = item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 18;
            item.knockBack = 1.3f;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(0, 0, 50);
            item.useAnimation = 18;
            item.height = dims.Height;
        }
    }
}
