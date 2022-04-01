using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class SolarFlareBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solarium Bow");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 69;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 9f;
            Item.DamageType = DamageClass.Ranged;
            Item.rare = ItemRarityID.Cyan;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.knockBack = 7f;
            Item.useTime = 24;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.useAnimation = 24;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item5;
        }
    }
}
