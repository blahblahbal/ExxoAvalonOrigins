using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
    class LimeGreenSolution : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lime Solution");
            Tooltip.SetDefault("Used by the Clentaminator\nSpreads the Jungle");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.ammo = AmmoID.Solution;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.consumable = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.LimeSolution>() - ProjectileID.PureSpray;
            Item.value = Item.buyPrice(0, 0, 25, 0);
            Item.maxStack = 2000;
            Item.height = dims.Height;
        }
        public override bool ConsumeAmmo(Player player)
        {
            return player.itemAnimation >= player.HeldItem.useAnimation - 3;
        }
    }
}
