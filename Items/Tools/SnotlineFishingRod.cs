using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class SnotlineFishingRod : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snotline Fishing Rod");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.shootSpeed = 16.5f;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.useTime = 8;
            Item.fishingPole = 25;
            Item.shoot = ModContent.ProjectileType<Projectiles.SnotlineBobber>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 40, 0, 0);
            Item.useAnimation = 8;
            Item.height = dims.Height;
        }
    }
}
