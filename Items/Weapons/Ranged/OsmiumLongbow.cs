using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class OsmiumLongbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Osmium Longbow");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item5;
            Item.damage = 24;
            Item.useTurn = true;
            Item.scale = 1f;
            Item.shootSpeed = 9f;
            Item.useAmmo = AmmoID.Arrow;
            Item.DamageType = // item.noMelee = true /* tModPorter - this is redundant, for more info see https://github.com/tModLoader/tModLoader/wiki/Update-Migration-Guide#damage-classes */ ;
            Item.width = dims.Width;
            Item.useTime = 17;
            Item.knockBack = 1.4f;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 0, 50);
            Item.useAnimation = 17;
            Item.height = dims.Height;
        }
    }
}
