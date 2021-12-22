using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class IridiumPlateMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iridium Plate Mail");
            Tooltip.SetDefault("Increases maximum mana by 50");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 9;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 1, 40, 0);
            item.height = dims.Height;
        }
        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 50;
        }
    }
}
