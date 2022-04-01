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
            Item.UseSound = SoundID.Item5;
            Item.damage = 21;
            Item.useTurn = true;
            Item.scale = 1f;
            Item.shootSpeed = 9f;
            Item.useAmmo = AmmoID.Arrow;
            Item.DamageType = // item.noMelee = true /* tModPorter - this is redundant, for more info see https://github.com/tModLoader/tModLoader/wiki/Update-Migration-Guide#damage-classes */ ;
            Item.width = dims.Width;
            Item.useTime = 18;
            Item.knockBack = 1.3f;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 0, 50);
            Item.useAnimation = 18;
            Item.height = dims.Height;
        }
    }
}
