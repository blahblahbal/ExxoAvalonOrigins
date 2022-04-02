using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class BandofSlime : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Band of Slime");
        Tooltip.SetDefault("Reduces damage taken by 5% and negates fall damage\nAll tiles are slippery");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Items/Accessories/BandofSlime");
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = 50000;
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().slimeBand = true;
        player.endurance += 0.05f;
        player.noFallDmg = true;
        player.slippy2 = true;
    }
}