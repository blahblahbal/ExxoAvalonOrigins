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
            item.damage = 69;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 9f;
            item.ranged = true;
            item.rare = ItemRarityID.Cyan;
            item.noMelee = true;
            item.width = dims.Width;
            item.knockBack = 7f;
            item.useTime = 24;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.useAnimation = 24;
            item.height = dims.Height;
            item.UseSound = SoundID.Item5;
        }
    }
}
