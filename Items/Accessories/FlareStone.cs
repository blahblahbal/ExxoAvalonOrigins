using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class FlareStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flare Stone");
            Tooltip.SetDefault("Damage taken from lava contact is reduced\nWeapons inflict fire damage and provides immunity to fire blocks");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 3, 50, 0);
            item.accessory = true;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lavaRose = true;
            player.fireWalk = true;
            player.magmaStone = true;
        }
    }
}
