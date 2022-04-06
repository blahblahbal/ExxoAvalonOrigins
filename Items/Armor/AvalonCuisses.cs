using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
class AvalonCuisses : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Avalon Cuisses");
        Tooltip.SetDefault("30% increased critical damage"
                           + "\n10% increased melee speed"
                           + "\nLightning strikes when damaged");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Items/Armor/AvalonCuisses");
        Item.defense = 38;
        Item.rare = ModContent.RarityType<Rarities.AvalonRarity>();
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 41, 0, 0);
        Item.height = dims.Height;
    }
    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.15f;
        player.meleeSpeed += 0.10f;
        player.Avalon().LightningInABottle = true;
    }
}
