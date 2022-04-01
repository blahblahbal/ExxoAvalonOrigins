using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class AegisDash : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aegis Dash");
            Tooltip.SetDefault("Dash into enemies to damage them");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 70;
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.knockBack = 10f;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 7, 0, 0);
            Item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.dash = 2;
            player.Avalon().dashIntoMob = true;
        }
    }
}
