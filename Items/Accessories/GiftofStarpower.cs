using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class GiftofStarpower : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Gift of Starpower");
        Tooltip.SetDefault("20% decreased mana usage and +40 mana\nAutomatically use mana potions when needed and 15% increased magic damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 8, 0, 0);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.manaCost -= 0.2f;
        player.statManaMax2 += 40;
        player.manaFlower = true;
        player.GetDamage(DamageClass.Magic) += 0.15f;
    }
}