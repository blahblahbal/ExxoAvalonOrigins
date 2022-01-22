using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    public class HadesCross : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hades' Cross");
            Tooltip.SetDefault("Provides the ability to breathe in, and free movement in lava\nNegates damage from lava");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 3;
            item.rare = ItemRarityID.LightPurple;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 9, 72, 0);
            item.accessory = true;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            bool flag = Collision.LavaCollision(player.position, player.width, player.height);
            if (flag)
            {
                player.Avalon().mermanLava = true;
                player.merman = true;
                player.accFlipper = true;
                player.ignoreWater = true;
                player.lavaImmune = true;
            }
            player.lavaImmune = true;
            player.fireWalk = true;
            player.waterWalk = true;
        }
    }
}
