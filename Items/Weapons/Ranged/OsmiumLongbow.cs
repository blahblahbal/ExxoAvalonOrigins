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
            item.UseSound = SoundID.Item5;
            item.damage = 24;
            item.useTurn = true;
            item.scale = 1f;
            item.shootSpeed = 9f;
            item.useAmmo = AmmoID.Arrow;
            item.ranged = item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 17;
            item.knockBack = 1.4f;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(0, 0, 50);
            item.useAnimation = 17;
            item.height = dims.Height;
        }
    }
}
