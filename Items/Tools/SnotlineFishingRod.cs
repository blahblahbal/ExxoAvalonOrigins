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
            item.shootSpeed = 16.5f;
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.useTime = 8;
            item.fishingPole = 25;
            item.shoot = ModContent.ProjectileType<Projectiles.SnotlineBobber>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 40, 0, 0);
            item.useAnimation = 8;
            item.height = dims.Height;
        }
    }
}
