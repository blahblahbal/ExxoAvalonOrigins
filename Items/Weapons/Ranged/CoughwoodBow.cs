using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class CoughwoodBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coughwood Bow");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item5;
            Item.damage = 9;
            Item.useTurn = true;
            Item.scale = 1f;
            Item.shootSpeed = 7f;
            Item.useAmmo = AmmoID.Arrow;
            Item.DamageType = DamageClass.Ranged;
            Item.rare = ItemRarityID.White;
            Item.width = dims.Width;
            Item.useTime = 20;
            Item.knockBack = 0f;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.useAnimation = 20;
            Item.height = dims.Height;
        }
    }
}
