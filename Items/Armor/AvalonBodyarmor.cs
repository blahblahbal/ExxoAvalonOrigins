using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class AvalonBodyarmor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Avalon Bodyarmor");
            Tooltip.SetDefault("10% increased critical strike chance"
                + "\nGreatly increases length of invincibility after taking damage"
                + "\nStars fall when injured");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Items/Armor/AvalonBodyarmor");
            item.defense = 42;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 41, 0, 0);
            item.height = dims.Height;
        }
        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 10;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.thrownCrit += 10;
            player.Avalon().critDamageMult += 0.30f;
            player.longInvince = true;
            player.starCloak = true;
        }
    }
}
