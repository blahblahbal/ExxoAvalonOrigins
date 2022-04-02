using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Body)]
class UnvolanditeBodyplate : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Unvolandite Bodyplate");
        Tooltip.SetDefault("Enemies are a lot more likely to target you\nMinion knockback is increased by 10%");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 33;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 40, 0, 0);
        Item.height = dims.Height;
    }

    public override void UpdateEquip(Player player)
    {
        player.aggro += 1500;
        player.minionKB += 0.1f;
    }
}