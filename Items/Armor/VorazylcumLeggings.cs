using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class VorazylcumLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vorazylcum Leggings");
            Tooltip.SetDefault("Increases your max number of minions by 3\nIncreases maximum mana by 100");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 33;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 30, 0, 0);
            item.height = dims.Height;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 3;
            player.statManaMax2 += 100;
        }
    }
}
