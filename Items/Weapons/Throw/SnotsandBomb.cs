using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Throw
{
    class SnotsandBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snotsand Bomb");
            Tooltip.SetDefault("An explosion of snotsand that will not destroy tiles");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.noUseGraphic = true;
            Item.damage = 0;
            Item.maxStack = 999;
            Item.shootSpeed = 5f;
            Item.consumable = true;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 25;
            Item.shoot = ModContent.ProjectileType<Projectiles.SnotsandBomb>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.buyPrice(0, 0, 4, 0);
            Item.useAnimation = 25;
            Item.height = dims.Height;
        }
    }
}
