using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class DurataniumRepeater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duratanium Repeater");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item5;
            item.damage = 31;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 10.5f;
            item.ranged = true;
            item.noMelee = true;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.useTime = 21;
            item.knockBack = 1.5f;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 68000;
            item.useAnimation = 21;
            item.height = dims.Height;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3, -3);
        }
    }
}
