using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged;

class IridiumLongbow : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Iridium Longbow");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item5;
        Item.damage = 25;
        Item.useTurn = true;
        Item.scale = 1f;
        Item.shootSpeed = 10f;
        Item.useAmmo = AmmoID.Arrow;
        Item.DamageType = // item.noMelee = true /* tModPorter - this is redundant, for more info see https://github.com/tModLoader/tModLoader/wiki/Update-Migration-Guide#damage-classes */ ;
            Item.width = dims.Width;
        Item.useTime = 16;
        Item.knockBack = 2f;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.rare = ItemRarityID.LightRed;
        Item.value = 25000;
        Item.useAnimation = 16;
        Item.height = dims.Height;
    }
}