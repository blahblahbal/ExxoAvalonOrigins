using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class NaquadahRepeater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naquadah Repeater");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 36;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 10.5f;
            item.ranged = true;
            item.noMelee = true;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.useTime = 20;
            item.knockBack = 2.05f;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 70000;
            item.useAnimation = 20;
            item.height = dims.Height;
            item.UseSound = SoundID.Item5;
        }
    }
}
