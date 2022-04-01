using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class BloodstainedHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodstained Helmet");
            Tooltip.SetDefault("Shows the location of treasures and ores\nWorks in the vanity slot");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 3;
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 0, 90, 0);
            Item.height = dims.Height;
        }

        public override void UpdateVanity(Player player, EquipType type)
        {
            player.findTreasure = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.findTreasure = true;
        }
    }
}
