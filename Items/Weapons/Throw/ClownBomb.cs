using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Throw
{
    class ClownBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clown Bomb");
            Tooltip.SetDefault("An explosion that will not destroy tiles");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.noUseGraphic = true;
            item.damage = 75;
            item.maxStack = 999;
            item.shootSpeed = 5f;
            item.consumable = true;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 25;
            item.shoot = ModContent.ProjectileType<Projectiles.ClownBomb>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.buyPrice(0, 0, 4, 0);
            item.useAnimation = 25;
            item.height = dims.Height;
        }
    }
}
