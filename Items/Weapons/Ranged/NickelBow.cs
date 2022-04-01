using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class NickelBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Bow");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item5;
            Item.damage = 10;
            Item.useTurn = true;
            Item.scale = 1f;
            Item.shootSpeed = 6.5f;
            Item.useAmmo = AmmoID.Arrow;
            Item.DamageType = // item.noMelee = true /* tModPorter - this is redundant, for more info see https://github.com/tModLoader/tModLoader/wiki/Update-Migration-Guide#damage-classes */ ;
            Item.width = dims.Width;
            Item.useTime = 27;
            Item.knockBack = 0f;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 1800;
            Item.useAnimation = 27;
            Item.height = dims.Height;
        }
    }
}
