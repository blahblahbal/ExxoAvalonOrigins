using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class ZirconHook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zircon Hook");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.noUseGraphic = true;
            item.useTurn = true;
            item.shootSpeed = 16f;
            item.rare = ItemRarityID.Green;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 20;
            item.knockBack = 7f;
            item.shoot = ModContent.ProjectileType<Projectiles.ZirconHook>();
            item.value = Item.sellPrice(0, 0, 54, 0);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 20;
            item.height = dims.Height;
        }
    }
}
