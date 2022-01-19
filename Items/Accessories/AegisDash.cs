using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    internal class AegisDash : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aegis Dash");
            Tooltip.SetDefault("Dash into enemies to damage them");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 70;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.knockBack = 10f;
            item.accessory = true;
            item.value = Item.sellPrice(0, 7, 0, 0);
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.dash = 2;
            player.Avalon().dashIntoMob = true;
        }
    }
}
